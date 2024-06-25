#include "Waitor.h"

using namespace std;

Waitor::Waitor()
{
    this->name = "";
    this->phoneNum = "";
    this->email = "";
}

Waitor::Waitor(string n, string pn, string em)
{
    this->name = n;
    this->phoneNum = pn;
    this->email = em;
}

Waitor::~Waitor() // DESTRUCTOR
{
    // cout << "Waitor " << this->name << " has been deleted." << endl;
}
