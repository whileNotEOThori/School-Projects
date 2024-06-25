#ifndef RESERVATION_H
#define RESERVATION_H
#include "Customer.h"
#include "Waitor.h"

using namespace std;

class Reservation
{
private:
    string restaurantName;
    int date;
    int tableNum;
    int numPatrons;
    double depositAmount;
    bool isDepositPaid;
    Customer *customer;
    Waitor *waitor;

public:
    Reservation();
    ~Reservation();
    string getRestaurantName();
    void setRestaurantName(string rn);
    int getDate();
    void setDate(int d);
    int getTableNum();
    void setTableNum(int tn);
    int getNumPatrons();
    void setNumPatrons(int p);
    double getDepositAmount();
    void setDepositAmount(double da);
    bool getIsDepositPaid();
    void setIsDepositPaid(bool dp);
    Customer *getCustomer();
    void setCustomer(Customer *c);
    Waitor *getWaitor();
    void setWaitor(Waitor *w);
    void viewReservation();
};

#endif