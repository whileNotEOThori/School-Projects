#include "User.h"
using namespace std;

User::User()
{
    this->name = "";
    this->phoneNum = "";
    this->email = "";
}

User::User(string n, string pn, string em)
{
    this->name = n;
    this->phoneNum = pn;
    this->email = em;
}

User::~User()
{
    // cout << "User " << this->name << " has been deleted." << endl;
}

string User::getName()
{
    return this->name;
}

void User::setName(string n)
{
    this->name = n;
}

string User::getPhoneNum()
{
    return this->phoneNum;
}

void User::setPhoneNum(string pn)
{
    this->phoneNum = pn;
}

string User::getEmail()
{
    return this->email;
}

void User::setEmail(string em)
{
    this->email = em;
}

// helper function // COMPLETE. WORKS
void User::displayUser()
{
    cout << "Name: " << getName() << endl;
    cout << "Phone Number: " << getPhoneNum() << endl;
    cout << "Email: " << getEmail() << endl;
}