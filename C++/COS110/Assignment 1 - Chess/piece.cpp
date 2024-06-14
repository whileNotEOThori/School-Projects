#include "piece.h"

piece::piece() // DEFAULT CONSTRUCTOR
{
}

// COPY CONSTRUCTOR
piece::piece(piece *newPiece)
{
    this->pieceType = newPiece->getPiece();
    this->side = newPiece->getSide();
    this->xPos = newPiece->getX();
    this->yPos = newPiece->getY();
}

// VALUE BASED CONSTRUCTOR
piece::piece(string p, char s, int x, int y)
{
    this->pieceType = p;
    this->side = s;
    this->xPos = x;
    this->yPos = y;
}

piece::~piece() // DESTRUCTOR
{
    cout << "(" << this->xPos << "," << this->yPos << ") " << this->side << " " << this->getPiece() << " deleted" << endl;
}

char piece::getSide()
{
    return this->side;
}

int piece::getX()
{
    return this->xPos;
}

int piece::getY()
{
    return this->yPos;
}

void piece::setX(int x)
{
    this->xPos = x;
}

void piece::setY(int y)
{
    this->yPos = y;
}

void piece::printPiece()
{
    cout << this->side << " " << this->getPiece() << " at " << "[" << this->xPos << "," << this->yPos << "]" << endl;
}

string piece::getPiece()
{
    return pieceType;
}