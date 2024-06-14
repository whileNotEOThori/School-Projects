#include "board.h"
#include <string>
#include <iostream>
using namespace std;

int x1, x2, y_one, y2;

// CLASS DEFINITIONS
// CONSTRUCTOR
board::board(string pieceList)
{
    ifstream inputfile;

    // OPEN THE TEXTFILE
    inputfile.open(pieceList);

    if (inputfile.fail())
    {
        cout << "There was an error in opening the file.\n";
    }
    else
    {
        // LOACL VARIABLE DECLARATION
        string line;
        int pos, white = 0, black = 0;
        ifstream inputfile;

        // TESTING
        // cout << "in if statement" << endl;

        // CREATE A DYNAMIC 2-D FOR THE CHESSBOARD
        chessboard = new string *[8];
        for (int i = 0; i < 8; i++)
        {
            chessboard[i] = new string[8];
        }

        // POPULATE THE CHESSBOARD ARRAY WITH BLANKS
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                chessboard[i][j] = "-";
            }
        }

        /*// TESTING - PRINT AFTER INTATIATION
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                cout << chessboard[i][j] << " ";
            }
            cout << endl;
        }
        cout << endl;*/

        // READ THE FIRST LINE OF THE TEXTFILE WITH THE SIDE TO MOVE
        // inputfile >> line;
        getline(inputfile, line);
        sideToMove = line[0];

        cout << sideToMove << endl;

        // READ THE SECOND LINE OF THE TEXTFILE WITH THE COORDINATES OF THE MOVE
        // inputfile >> line;
        getline(inputfile, line);
        cout << line << endl;

        // DATA PROCESSING: FIND THE INITIAL AND FINAL COORDINATES
        pos = line.find(",", 0);
        x1 = stoi(line.substr(0, pos));
        line.erase(0, pos + 1);
        y_one = stoi(line.substr(0, pos));
        line.erase(0, pos + 1);
        x2 = stoi(line.substr(0, pos));
        line.erase(0, pos + 1);
        y2 = stoi(line);

        while (getline(inputfile, line)) // b,king,0,0
        {
            // LOOP VARIABLE DECLARATION
            string piece;
            char side, p;
            int x, y;

            // DATA PROCESSING: EXTRACT THE SIDE, PIECES AND COORDINATES
            side = line[0];
            line.erase(0, 2);

            pos = line.find(",", 0);
            piece = line.substr(0, pos);
            line.erase(0, pos + 1);

            x = line[0];
            y = line[2];

            // DETERMINE THE PIECE SHORTHAND
            if (piece == "king")
            {
                p = 'K';
            }
            else if (piece == "queen")
            {
                p = 'q';
            }
            if (piece == "pawn")
            {
                p = 'p';
            }
            else if (piece == "bishop")
            {
                p = 'b';
            }
            else if (piece == "knight")
            {
                p = 'k';
            }
            else if (piece == "rook")
            {
                p = 'r';
            }

            // TESTING -
            cout << side << p << endl;
            // POLPULATE THE CHESSBOARD ARRAY
            chessboard[x][y] = side + p;

            // DETERMINE THE NUMBERS OF WHITE AND BLACK PIECES
            switch (toupper(side)) // USE TOUPPER TO FACILITATE DISCREPANCIES
            {
            case 'W':
            {
                white++;
                break;
            }
            case 'B':
                black++;
            }

            // ASSIGN THE BLACK AND WHITE VALUES TO THE VARIABLES
            numWhitePieces = white;
            numBlackPieces = black;
        }

        // TESTING
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                cout << chessboard[i][j] << " ";
            }
            cout << endl;
        }

        // CLOSE THE FILE
        inputfile.close();
    }
}

// DESTRUCTOR
board::~board()
{
    // DEALLOCATE THE MEMORY USED BY THE CHESSBOARD ARRAY
    for (int i = 0; i < 8; i++)
    {
        delete[] chessboard[i];
    }
    delete[] chessboard;

    // PRINT THE NECESSARY MESSAGE
    cout << "Num Pieces Removed: " << numWhitePieces + numBlackPieces << endl;
}

/*
void board::applyMove()
{
}

bool board::checkIfPieceHasCheck(string pieceType, int xPos, int yPos, int kingX, int kingY)
{
}

void board::determineIfCheckMate()
{
}*/
