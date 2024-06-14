#ifndef piece_h
#define piece_h
#include <iostream>
#include <iomanip>
#include <string>
using namespace std;

class piece
{
private: /// CLASS VARIABLE DECLARATION
    string pieceType;
    char side;
    int xPos;
    int yPos;

public:
    piece();                               // DEFAULT CONSTRUCTOR
    piece(piece *newPiece);                // COPY CONSTRUCTOR
    piece(string p, char s, int x, int y); // VALUE BASED CONSTRUCTOR
    ~piece();                              // DESTRUCTOR
    char getSide();
    int getX();
    int getY();
    void setX(int x);
    void setY(int y);
    void printPiece();
    string getPiece(); // ADDITIONAL
};

#endif