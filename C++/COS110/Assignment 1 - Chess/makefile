main:		piece.o board.o main.cpp
			g++ -g -static piece.o board.o main.cpp -o main

piece.o: 	piece.cpp
			g++ -static -c piece.cpp

board.o:	board.cpp
			g++ -static -c board.cpp

run: 		
			./main

clean: 		rm -f *.o task1

tar:		tar -cvz *.h *.cpp *.txt makefile Ass1.tar.gz