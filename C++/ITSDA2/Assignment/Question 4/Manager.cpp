#include "Manager.h"

using namespace std;

Manager::Manager()
{
    this->name = "";
    this->phoneNum = "";
    this->email = "";
    // this->restaurantName = nullptr;
}

Manager::Manager(string n, string pn, string em)
{
    this->name = n;
    this->phoneNum = pn;
    this->email = em;
}

Manager::~Manager() // DESTRUCTOR
{
    // cout << "Manager " << this->name << " has been deleted." << endl;
}

