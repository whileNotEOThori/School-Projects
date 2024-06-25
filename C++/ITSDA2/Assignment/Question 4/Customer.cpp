#include "Customer.h"

using namespace std;

Customer::Customer()
{
    this->name = "";
    this->phoneNum = "";
    this->email = "";
    this->reservation = nullptr;
}

Customer::Customer(string n, string pn, string em)
{
    this->name = n;
    this->phoneNum = pn;
    this->email = em;
    this->reservation = nullptr;
}

// COMPLETE. WORKS
Customer::~Customer() // DESTRUCTOR
{
    delete reservation;
    reservation = nullptr;

    // cout << "Customer " << this->name << " has been deleted." << endl;
}

Reservation *Customer::getReservation()
{
    return reservation;
}

void Customer::setReservation(Reservation *r)
{
    reservation = new Reservation();
    reservation->setRestaurantName(r->getRestaurantName());
    reservation->setDate(r->getDate());
    reservation->setTableNum(r->getTableNum());
    reservation->setNumPatrons(r->getNumPatrons());
    reservation->setDepositAmount(r->getDepositAmount());
    reservation->setIsDepositPaid(r->getIsDepositPaid());
    reservation->setWaitor(r->getWaitor());
    reservation->setCustomer(this);
}
