#ifndef USER_H
#define USER_H
#include <iostream>
#include <string>

using namespace std;

class User
{
protected:
    string name;
    string phoneNum;
    string email;
    // string restaurant;

public:
    User();
    User(string n, string pn, string em);
    ~User(); // DESTRUCTOR
    string getName();
    void setName(string n);
    string getPhoneNum();
    void setPhoneNum(string pn);
    string getEmail();
    void setEmail(string em);
    void displayUser(); // helper function
};

#endif