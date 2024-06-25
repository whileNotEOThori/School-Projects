#ifndef RESTAURANT_H
#define RESTAURANT_H
#include "Waitor.h"
#include "Manager.h"
#include "Reservation.h"

using namespace std;

class Restaurant
{
private:
    string restaurantName;
    Manager *manager;
    int numWaitors;
    int MaxReservations;
    Waitor **waitors;
    Reservation **reservations;

public:
    Restaurant();
    ~Restaurant();
    string getRestaurantName();
    void setRestaurantName(string rn);
    Manager *getManager();
    void setManager(Manager *m);
    int getNumWaitors();
    void setNumWaitors(int nw);
    int getMaxReservations();
    void setMaxReservations(int mr);
    Waitor **getWaitors();
    void setWaitors(Waitor **w); // create deep copy
    void printRestaurant();
    Reservation **getReservations();
    void setReservations();
};

#endif