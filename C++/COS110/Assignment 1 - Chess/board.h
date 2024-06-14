#ifndef board_h
#define board_h
#include "piece.h"
#include <fstream>
#include <string>

class board
{
private:
    int numWhitePieces;
    int numBlackPieces;
    piece **whitePieces;
    piece **blackPieces;
    string **chessboard;
    string move;
    char sideToMove;
    void applyMove();

public:
    board(string pieceList);
    ~board(); // DESTRUCTOR
    void determineIfCheckMate();
    bool checkIfPieceHasCheck(string pieceType, int xPos, int yPos, int kingX, int kingY);
};

#endif