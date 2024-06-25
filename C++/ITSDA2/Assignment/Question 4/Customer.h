#ifndef CUSTOMER_H
#define CUSTOMER_H
#include "User.h"
#include "Reservation.h"

using namespace std;

class Customer : public User
{
private:
    Reservation *reservation;

public:
    Customer();
    Customer(string n, string pn, string em);
    ~Customer(); // DESTRUCTOR
    Reservation *getReservation();
    void setReservation(Reservation *r);
};

#endif