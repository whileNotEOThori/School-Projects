#include "Restaurant.h"

using namespace std;

Restaurant::Restaurant()
{
    restaurantName = "";
    manager = nullptr;
    numWaitors = 0;
    MaxReservations = 0;
    waitors = nullptr;
    reservations = nullptr;
}

Restaurant::~Restaurant()
{
    delete manager;
    manager = nullptr;

    for (int i = 0; i < numWaitors; i++)
    {
        delete waitors[i];
    }
    delete[] waitors;
    waitors = nullptr;

    for (int i = 0; i < MaxReservations; i++)
    {
        delete reservations[i];
    }
    delete[] reservations;
    reservations = nullptr;
}

string Restaurant::getRestaurantName()
{
    return restaurantName;
}

void Restaurant::setRestaurantName(string rn)
{
    restaurantName = rn;
}

Manager *Restaurant::getManager()
{
    return manager;
}

void Restaurant::setManager(Manager *m)
{
    manager = new Manager();
    this->manager->setName(m->getName());
    this->manager->setEmail(m->getEmail());
    this->manager->setPhoneNum(m->getPhoneNum());
}

int Restaurant::getNumWaitors()
{
    return numWaitors;
}

void Restaurant::setNumWaitors(int nw)
{
    this->numWaitors = nw;
}

int Restaurant::getMaxReservations()
{
    return MaxReservations;
}

void Restaurant::setMaxReservations(int mr)
{
    this->MaxReservations = mr;
}

Waitor **Restaurant::getWaitors()
{
    return waitors;
}

void Restaurant::setWaitors(Waitor **w) // create deep copy
{
    waitors = new Waitor *[numWaitors];

    for (int i = 0; i < numWaitors; i++)
    {
        waitors[i] = new Waitor();
        waitors[i]->setName(w[i]->getName());
        waitors[i]->setPhoneNum(w[i]->getPhoneNum());
        waitors[i]->setEmail(w[i]->getEmail());
    }
}

void Restaurant::printRestaurant()
{
    cout << "Restaurant's information:" << endl;
    cout << "Restaurant Name: " << getRestaurantName() << endl;
    cout << "Manager's information:" << endl;
    getManager()->displayUser();
    cout << "Number of waitors: " << getNumWaitors() << endl;
    cout << "Max number of reservations: " << getMaxReservations() << endl;
    cout << "Watoirs' information:" << endl;
    for (int i = 0; i < getNumWaitors(); i++)
    {
        waitors[i]->displayUser();
    }
    cout << "Reservations information:" << endl;
    for (int i = 0; i < getMaxReservations(); i++)
    {
        cout << i + 1 << ".";
        if (reservations[i] == nullptr)
            cout << "Available" << endl;
        else
            reservations[i]->viewReservation();
    }
}

Reservation **Restaurant::getReservations()
{
    return reservations;
}

void Restaurant::setReservations()
{
    reservations = new Reservation *[MaxReservations];

    for (int i = 0; i < MaxReservations; i++)
    {
        reservations[i] = nullptr;
    }
}
