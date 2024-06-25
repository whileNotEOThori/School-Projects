#ifndef WAITOR_H
#define WAITOR_H
#include "User.h"
// #include "Reservation.h"

using namespace std;

class Waitor : public User
{
private:
public:
    Waitor();
    Waitor(string n, string pn, string em);
    ~Waitor(); // DESTRUCTOR
};

#endif