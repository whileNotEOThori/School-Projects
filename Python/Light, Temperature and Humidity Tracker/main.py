import RPi.GPIO as GPIO
import Adafruit_DHT
from datetime import datetime
import time
import os
import array
import shutil

GPIO.setmode(GPIO.BCM)

DHT_SENSOR = Adafruit_DHT.DHT22

LDR_PIN=21
DHT_PIN = 20

INTERVAL_READINGS= 1000
total_readings = 0
first_reading = 0

temperatures = array.array('f')
humidities = array.array('f')
resistance_readings = array.array('f')

while True:                             #loop indefinitely
    resistance_reading = 0

    GPIO.setup(LDR_PIN,GPIO.OUT)        #Set at output pin
    GPIO.output(LDR_PIN,GPIO.LOW)       #set pin to 0V to discharge capacitor

    time.sleep(1)                       #wait 1 second so that the capacitor can discharge fully

    GPIO.setup(LDR_PIN,GPIO.IN)         #set as input pin

    while(GPIO.input(LDR_PIN) == GPIO.LOW):             #loop while pin is 0V
        resistance_reading += 1

    print("Resistance reading: " + resistance_reading)

    humidity, temperature = Adafruit_DHT.read_retry(DHT_SENSOR, DHT_PIN)    #get temperature and humidity reading

    if humidity is not None and temperature is not None:
        print('Temperature={0}*C  Humidity={1}%'.format(temperature, humidity))
    else:
        print('Failed to get reading. Try again!')

    # add readings to their respective arrays
    temperatures.append(temperature)
    humidities.append(humidity)
    resistance_readings.append(resistance_reading)

    #execute every 1000 readings
    if total_readings % INTERVAL_READINGS == 0 and total_readings >= INTERVAL_READINGS:
        version = total_readings/INTERVAL_READINGS
        filename = "readings" + str(version) + ".txt"
        textfile = open(filename,"a")  #create a new text file

        #write the date and time to the first line
        textfile.write(str(datetime.now()))
        
        #write the readings to the textfile. Separate them with a #
        for i in range(INTERVAL_READINGS):
            textfile.write(str(resistance_readings[i]) + "#" + str(temperatures[i]) + "#" + str(humidities[i]) + "\n")            

        textfile.close()
        print("Readings {0} to {1} have been saved to {2}".format(first_reading,total_readings,filename))
        first_reading = total_readings + 1

        #execute if more than 2000 readings have been taken
        if version > 1:
            filename = "readings" + str(version - 1.0) + ".txt"
            ##################################################################################### 
            #code that will transmit the textfile with the above filename to a web server via TCP
            #to simulate this transfer we will move the files to another folder then delete the local copy
            current_directory = 'C:\\Users\THORISO\Desktop\\' + filename
            TCP_directory = 'C:\\Users\THORISO\Desktop\WebServer\\' + filename
            shutil.move(current_directory, TCP_directory)
            #####################################################################################
            print("{0} has been transited via TCP to the web server".format(filename))
            print("{0} has been deleted from the local storage".format(filename))

        #purge the readings arrays for the next batch of readings
        for i in range(INTERVAL_READINGS):
            resistance_readings.pop()
            temperatures.pop()
            humidities.pop()

    total_readings += 1 #increase counter
    time.sleep(1) #1 second interval between readings


GPIO.cleanup()

#//////////////////////////////////////////////////////////////////////////////////////////////////////////////
# LDR: Light intensity and resistance are inversely proportional  
#  git clone https://github.com/adafruit/Adafruit_Python_DHT.git
# cd Adafruit_Python_DHT
# sudo apt-get install build-essential python-openssl
# sudo python3 setup.py install