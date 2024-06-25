#include "Reservation.h"

using namespace std;

Reservation::Reservation()
{
    restaurantName = "";
    date = 0;
    tableNum = 0;
    numPatrons = 0;
    depositAmount = 0.00;
    isDepositPaid = false;
    customer = nullptr;
    waitor = nullptr;
}

Reservation::~Reservation()
{
    delete customer;
    delete waitor;
    customer = nullptr;
    waitor = nullptr;
}

string Reservation::getRestaurantName()
{
    return restaurantName;
}

void Reservation::setRestaurantName(string rn)
{
    restaurantName = rn;
}

int Reservation::getDate()
{
    return date;
}

void Reservation::setDate(int d)
{
    date = d;
}

int Reservation::getTableNum()
{
    return tableNum;
}

void Reservation::setTableNum(int tn)
{
    tableNum = tn;
}

int Reservation::getNumPatrons()
{
    return numPatrons;
}

void Reservation::setNumPatrons(int p)
{
    numPatrons = p;
}

double Reservation::getDepositAmount()
{
    return depositAmount;
}

void Reservation::setDepositAmount(double da)
{
    depositAmount = da;
}

bool Reservation::getIsDepositPaid()
{
    return isDepositPaid;
}

void Reservation::setIsDepositPaid(bool dp)
{
    isDepositPaid = dp;
}

Customer *Reservation::getCustomer()
{
    return customer;
}

void Reservation::setCustomer(Customer *c)
{
    customer = new Customer();
    customer->setName(c->getName());
    customer->setPhoneNum(c->getPhoneNum());
    customer->setEmail(c->getEmail());
}

Waitor *Reservation::getWaitor()
{
    return waitor;
}

void Reservation::setWaitor(Waitor *w)
{
    waitor = new Waitor();
    waitor->setName(w->getName());
    waitor->setPhoneNum(w->getPhoneNum());
    waitor->setEmail(w->getEmail());
}

void Reservation::viewReservation()
{
    cout << "Reservation information" << endl;
    cout << "\tRestaurant name: " << getRestaurantName() << endl;
    cout << "\tDate: " << getDate() << endl;
    cout << "\tTable number: " << getTableNum() << endl;
    cout << "\tNumber of patrons: " << getNumPatrons() << endl;
    cout << "\tDeposit amount: " << getDepositAmount() << endl;
    cout << "\t:Is deposit paid " << getIsDepositPaid() << endl;
    cout << "Customer information" << endl;
    cout << "\tName: " << customer->getName() << endl;
    cout << "\tPhone number: " << customer->getPhoneNum() << endl;
    cout << "\tEmail: " << customer->getEmail() << endl;
    cout << "Waitor information" << endl;
    cout << "\tName: " << waitor->getName() << endl;
}


