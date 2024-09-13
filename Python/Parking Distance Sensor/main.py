#/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
# Open a Pi Pico, Micropython project on https://wokwi.com/ (https://wokwi.com/projects/new/micropython-pi-pico)
# Copy this code into the main.py file and simulate
# copy the code in the diagram.json file into the diagram.json file in the wokwi simulation
#////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
from machine import Pin  
import utime  
import time  
 
#turns the buzzer on for half a second then turns it off   
def toggle_Buzzer():  
    buzzer.value(True)  
    time.sleep(0.5)  
    buzzer.value(False)  
 
#turns red LED on for half a second then turns it off  
def toggle_RED():  
    RED_LED.value(True)  
    time.sleep(0.5)  
    RED_LED.value(False)  
   
#constant variables  
BUZZER_THRESHOLD = 10  
LED_THRESHOLD = 30  
RANGE = 100  
 
#ultrasonic sensor intialization  
trigger = Pin(22, Pin.OUT)  
echo = Pin(21, Pin.IN)  
 
#led intialization  
RED_LED = Pin(20, Pin.OUT)  
   
#buzzer initialization  
buzzer = Pin(19, Pin.OUT)  
 
while True:  
    #send out sound wave  
    trigger.value(False)    #deactivate trigger for 2 micro seconds  
    utime.sleep_us(2)          
    trigger.value(True)     #activate trigger for 5 micro seconds  
    utime.sleep_us(5)          
    trigger.value(False)    #deactive trigger  
   
    #detect sound wave signal sent back  
    while echo.value() == False:    #not detected  
        pass  
    echoLow = utime.ticks_us()    #record the time when no signal is recived  
    while echo.value() == True:     #detected  
        pass  
    echoHigh = utime.ticks_us()     #record the time when a signal is recieved  
   
    distanceTime = utime.ticks_diff(echoHigh, echoLow)    #calculate the time to send and recived a signal  
    speed = 343 * 10**2 * 10**(-6)      #conversions: m-cm = 10**2, s-us = 10**(-6)  
    distance = (distanceTime * speed)/2 #divide by 2 to get the distance to the detected object and not the distance there an back      
 
    print("Distance: " + str(distance)[:6] + " cm") #print distance to console  
 
    if distance <= BUZZER_THRESHOLD: #sound buzzer and turn led on if distance <=10cm 
        RED_LED.value(True)  
        toggle_Buzzer()  
        time.sleep(0.5)  
        RED_LED.value(False)  
    elif distance > BUZZER_THRESHOLD and  distance <= LED_THRESHOLD: #turn led on if 10cm < distance <= 30cm 
        toggle_RED()    
    elif distance > LED_THRESHOLD and distance <= RANGE : #display message if 30cm < distance <= 100cm 
        print("Within range")          
    else:  
        print("Out of range. No object detected") #display message if distance > 100cm 
 
    time.sleep(0.1) #delay between measures 