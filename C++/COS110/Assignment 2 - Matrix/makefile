main:matrix.o main.cpp
	g++ -g -static matrix.o main.cpp -o main

matrix.o: matrix.cpp   
	g++ -static -c matrix.cpp

run:
	./main

clean:
	rm -f *.o main

tar:
	tar -cvz matrix.cpp matrix.h input.txt inputb.txt inputoutput.txt makefile main.cpp -f Ass2.tar.gz
 