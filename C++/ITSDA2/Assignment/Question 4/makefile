WRS:			User.o Customer.o Waitor.o Manager.o Restaurant.o Reservation.o WRS.cpp
				g++ -g -static User.o Customer.o Waitor.o Manager.o Restaurant.o Reservation.o WRS.cpp -o WRS

User.o: 		User.cpp
				g++ -static -c User.cpp

Customer.o: 		Customer.cpp
				g++ -static -c Customer.cpp

Waitor.o: 		Waitor.cpp
				g++ -static -c Waitor.cpp

Manager.o: 		Manager.cpp
				g++ -static -c Manager.cpp

Restaurant.o: 	Restaurant.cpp
				g++ -static -c Restaurant.cpp

Reservation.o: 	Reservation.cpp
				g++ -static -c Reservation.cpp

run: 		
				./WRS

clean: 			rm -f *.o WRS

tar:			tar -cvz *.h *.cpp *.txt makefile WRS.tar.gz