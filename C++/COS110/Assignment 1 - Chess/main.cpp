#include <iostream>
#include <string>
#include "piece.h"
#include "board.h"
using namespace std;

int main()
{
    cout << "Hello World" << endl;
    piece p("King", 'w', 2, 2);
    piece l(p);

    p.printPiece();
    l.printPiece();

    p.setX(3);
    p.setY(3);

    p.printPiece();

    
}

/*string type = "rook";
char side = 'w';
int x = 1 , y =2;

piece p(type ,side , x , y);

p.setX(x);
p.setY(y);
cout<<p.getX()<<p.getY()<<endl;
//p.piece(type, side , x , y);
p.printPiece();
p.~piece();

piece newpiece = piece("pawn",'b',2,2);
piece(newpiece);
cout<<p.getX()<<p.getY()<<endl;
//p.piece(type, side , x , y);
p.printPiece();
p.~piece();

 return 0;   */

/*w
2,4,1,2
b,king,0,0
b,pawn,1,0
w,king,4,5
w,rook,6,1
w,rook,2,7
w,bishop,7,5
w,knight,2,4*/