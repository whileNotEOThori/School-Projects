#ifndef MANAGER_H
#define MANAGER_H
#include "User.h"
// #include "Restaurant.h"

using namespace std;

class Manager : public User
{
private:

public:
    Manager();
    Manager(string n, string pn, string em);
    ~Manager(); // DESTRUCTOR
};

#endif