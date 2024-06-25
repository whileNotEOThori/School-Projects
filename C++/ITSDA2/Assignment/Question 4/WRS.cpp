#include <fstream>
#include "Customer.h"
#include "Waitor.h"
#include "Manager.h"
#include "Restaurant.h"
#include "Reservation.h"

using namespace std;

const double DEPOSIT_PP = 150.00;

// global varaiables
ifstream file;
Customer **allCustomers;
Waitor **allWaitors;
Manager **allManagers;
Restaurant **allRestaurants;
int numAllCustomers = 0, numAllWaitors = 0, numAllManagers = 0, numAllRestaurants = 0;
string fileName, userName, userPhoneNum, userEmail;

// function prototypes
void menu();
int getOption();

// user
void getUserDetails();
void printUserDetails();
void displayLoginError();
void displayLoginMessage(string t);
void displayReservationConfirmation(Reservation *r);

// customer
void CustomerLogin();
void getAllCustomers();
void printallCustomers();
void clearallCustomers();
bool isValidCustomer();
Customer *findCustomer(string name);

// waitor
void WaitorLogin();
void getAllWaitors();
void printAllWaitors();
void clearAllWaitors();
bool isValidWaitor();
Waitor *findWaitor(string name);

// manager
void ManagerLogin();
void getAllManagers();
void printAllManagers();
void clearAllManagers();
bool isValidManager();
Manager *findManager(string name);

// restaurant
void getAllRestaurants();
void printAllRestaurants();
void clearAllRestaurants();
Restaurant *findRestaurant(string n);

// WRS
string MakeReservation(Customer *customer);
bool isReservationEligible();
int checkAvailability(Restaurant *r);

int main()
{
    int option;

    // read all textfile for a list of users and restaurants
    getAllCustomers();
    getAllWaitors();
    getAllManagers();
    getAllRestaurants();

    printAllRestaurants();

    // printUserDetails();

    menu();
    option = getOption();

    switch (option)
    {
    case 1:
        CustomerLogin();
        break;
    case 2:
        WaitorLogin();
        break;
    case 3:
        ManagerLogin();
        break;
    }

    clearallCustomers();
    clearAllWaitors();
    clearAllManagers();

    return 0;
}

// COMPLETE. WORKS
void menu()
{
    cout << "Wonders Reservation System" << endl;
    cout << "Login in as a: " << endl;
    cout << "1. Customer" << endl;
    cout << "2. Waitor" << endl;
    cout << "3. Manager" << endl;
    cout << "4. Exit" << endl;
}

// COMPLETE. WORKS
void getUserDetails()
{
    /*cout << "Enter the user's name: ";
    cin >> userName;

    cout << "Enter the user's phone number: ";
    cin >> userPhoneNum;

    cout << "Enter the user's email address: ";
    cin >> userEmail;*/
    userName = "Thoriso";
    userPhoneNum = "0636770440";
    userEmail = "thorisodibatana@gmail.com";
}

// COMPLETE. WORKS
void printUserDetails()
{
    cout << "User's name: " << userName << endl;
    cout << "User's phone number: " << userPhoneNum << endl;
    cout << "User's email: " << userEmail << endl;
}

// COMPLETE. WORKS
int getOption()
{
    int opt;

    cout << "Enter option: ";
    cin >> opt;

    return opt;
}

// COMPLETE. WORKS
void CustomerLogin()
{

    // getAllCustomers(fileName);

    // cout << numAllCustomers;

    // printallCustomers();

    if (isValidCustomer() == false)
    {
        displayLoginError();
        return;
    }

    Customer *customer = new Customer;
    customer->setName(userName);
    customer->setEmail(userEmail);
    customer->setPhoneNum(userPhoneNum);

    cout << endl;
    displayLoginMessage("Customer");
    cout << "Would you like to :" << endl;
    cout << "1. Make a reservation" << endl;
    cout << "2. View your reservation" << endl;

    //*/

    // clearallCustomers(customer);
}

// COMPLETE. WORKS
void WaitorLogin()
{

    // getAllWaitors(fileName);

    // printAllWaitors();

    if (isValidWaitor() == false)
    {
        displayLoginError();
        return;
    }

    cout << endl;
    displayLoginMessage("Waitor");
    cout << "Would you like to :" << endl;
    cout << "1. Make a reservation" << endl;
    cout << "2. View your resturant's reservations" << endl;

    // findWaitor("Thoriso")->displayUser();

    clearAllWaitors();
}

// COMPLETE. WORKS
void ManagerLogin()
{

    // getAllManagers(fileName);

    // printAllManagers();

    if (isValidManager() == false)
    {
        displayLoginError();
        return;
    }

    cout << endl;
    displayLoginMessage("Manager");
    cout << "Would you like to :" << endl;
    cout << "1. Make a reservation" << endl;
    cout << "2. Cancel a reservation" << endl;
    cout << "3. Update a reservation" << endl;
    cout << "4. View your resturant's reservations" << endl;

    // findManager("Thoriso")->displayUser();

    getAllRestaurants(); // seg fault
    printAllRestaurants();

    clearAllManagers();
}

// COMPLETE. WORKS
void getAllCustomers()
{
    string line, name, phoneNum, email;
    int pos, i = 0;
    fileName = "Customers.txt";

    // clearCustomers();
    numAllCustomers = 0;

    file.open(fileName);

    if (file.fail())
    {
        cout << "There has been an error in opening the file as it does not seem to exist." << endl;
        return;
    }

    // READ THROUGH THE TEXTFILE TO GET THE NUMBER OF customers
    while (getline(file, line))
    {
        numAllCustomers++;
    }

    file.close();

    allCustomers = new Customer *[numAllCustomers];

    file.open(fileName);

    // READ THROUGH THE TEXTFILE TO POPULATE THE customers ARRAY
    while (getline(file, line))
    {
        pos = line.find(",", 0);
        name = line.substr(0, pos);
        line.erase(0, pos + 1);

        pos = line.find(",", 0);
        phoneNum = line.substr(0, pos);
        line.erase(0, pos + 1);

        email = line;

        allCustomers[i] = new Customer(name, phoneNum, email);
        i++;
    }

    file.close();
}

// COMPLETE. WORKS
void printallCustomers()
{
    for (int i = 0; i < numAllCustomers; i++)
    {
        allCustomers[i]->displayUser();
        cout << endl;
    }
}

// COMPLETE. WORKS
void clearallCustomers()
{
    for (int i = 0; i < numAllCustomers; i++)
    {
        delete allCustomers[i];
    }
    delete[] allCustomers;
    allCustomers = nullptr;
}

// COMPLETE. WORKS
bool isValidCustomer()
{
    int i = 0;

    while (i < numAllCustomers)
    {
        if (allCustomers[i]->getEmail() != userEmail)
        {
            i++;
        }

        return true;
    }

    return false;
}

Customer *findCustomer(string name)
{
    int i = 0;

    while (i < numAllCustomers)
    {
        if (allCustomers[i]->getName() != n)
        {
            i++;
        }
        else
        {
            return allCustomers[i];
        }
    }

    return nullptr;
}

// COMPLETE. WORKS
void displayLoginError()
{
    cout << "You are not a registered user." << endl;
}

// COMPLETE. WORKS
void displayLoginMessage(string t)
{
    cout << "You are logged in as a " << t << endl;
    cout << "Welcome " << userName << endl;
}

// COMPLETE. WORKS
void getAllWaitors()
{
    string line, name, phoneNum, email;
    int pos, i = 0;
    fileName = "Waitors.txt";

    // clearCustomers();
    numAllWaitors = 0;

    file.open(fileName);

    if (file.fail())
    {
        cout << "There has been an error in opening the file as it does not seem to exist." << endl;
        return;
    }

    // READ THROUGH THE TEXTFILE TO GET THE NUMBER OF customers
    while (getline(file, line))
    {
        numAllWaitors++;
    }

    file.close();

    allWaitors = new Waitor *[numAllWaitors];

    file.open(fileName);

    // READ THROUGH THE TEXTFILE TO POPULATE THE customers ARRAY
    while (getline(file, line))
    {
        pos = line.find(",", 0);
        name = line.substr(0, pos);
        line.erase(0, pos + 1);

        pos = line.find(",", 0);
        phoneNum = line.substr(0, pos);
        line.erase(0, pos + 1);

        email = line;

        allWaitors[i] = new Waitor(name, phoneNum, email);
        i++;
    }

    file.close();
}

// COMPLETE. WORKS
void printAllWaitors()
{
    for (int i = 0; i < numAllWaitors; i++)
    {
        allWaitors[i]->displayUser();
        cout << endl;
    }
}

// COMPLETE. WORKS
void clearAllWaitors()
{
    for (int i = 0; i < numAllWaitors; i++)
    {
        delete allWaitors[i];
    }
    delete[] allWaitors;
    allWaitors = nullptr;
}

// COMPLETE. WORKS
bool isValidWaitor()
{
    int i = 0;

    while (i < numAllWaitors)
    {
        if (allWaitors[i]->getEmail() != userEmail)
        {
            i++;
        }

        return true;
    }

    return false;
}

// COMPLETE. WORKS
void getAllManagers()
{
    string line, name, phoneNum, email;
    int pos, i = 0;
    fileName = "Managers.txt";

    // clearCustomers();
    numAllManagers = 0;

    file.open(fileName);

    if (file.fail())
    {
        cout << "There has been an error in opening the file as it does not seem to exist." << endl;
        return;
    }

    // READ THROUGH THE TEXTFILE TO GET THE NUMBER OF customers
    while (getline(file, line))
    {
        numAllManagers++;
    }

    file.close();

    allManagers = new Manager *[numAllManagers];

    file.open(fileName);

    // READ THROUGH THE TEXTFILE TO POPULATE THE customers ARRAY
    while (getline(file, line))
    {
        pos = line.find(",", 0);
        name = line.substr(0, pos);
        line.erase(0, pos + 1);

        pos = line.find(",", 0);
        phoneNum = line.substr(0, pos);
        line.erase(0, pos + 1);

        email = line;

        allManagers[i] = new Manager(name, phoneNum, email);
        i++;
    }

    file.close();
}

// COMPLETE. WORKS
void printAllManagers()
{
    for (int i = 0; i < numAllManagers; i++)
    {
        allManagers[i]->displayUser();
        cout << endl;
    }
}

// COMPLETE. WORKS
void clearAllManagers()
{
    for (int i = 0; i < numAllManagers; i++)
    {
        delete allManagers[i];
    }
    delete[] allManagers;
    allManagers = nullptr;
}

// COMPLETE. WORKS
bool isValidManager()
{
    int i = 0;

    while (i < numAllManagers)
    {
        if (allManagers[i]->getEmail() != userEmail)
        {
            i++;
        }

        return true;
    }

    return false;
}

// COMPLETE. WORKS
Waitor *findWaitor(string n)
{
    int i = 0;

    while (i < numAllWaitors)
    {
        if (allWaitors[i]->getName() != n)
        {
            i++;
        }
        else
        {
            return allWaitors[i];
        }
    }

    return nullptr;
}

// COMPLETE. WORKS
Manager *findManager(string n)
{
    int i = 0;

    while (i < numAllManagers)
    {
        if (allManagers[i]->getName() != n)
        {
            i++;
        }
        else
        {
            return allManagers[i];
        }
    }

    return nullptr;
}

// WORKS
void getAllRestaurants()
{
    string line, restaurantName, managerName, waitorName;
    int pos, numWaitors, i = 0;
    fileName = "Restaurants.txt";
    Waitor **waitors = nullptr;

    file.open(fileName);

    if (file.fail())
    {
        cout << "There has been an error in opening the file as it does not seem to exist." << endl;
        return;
    }

    // READ THROUGH THE TEXTFILE TO GET THE NUMBER OF Restaurants
    while (getline(file, line))
    {
        numAllRestaurants++;
    }

    file.close();

    allRestaurants = new Restaurant *[numAllRestaurants];

    file.open(fileName);

    while (i < numAllRestaurants) // getline(file, line))
    {
        getline(file, line);
        pos = line.find(",", 0);
        restaurantName = line.substr(0, pos);
        line.erase(0, pos + 1);

        pos = line.find(",", 0);
        managerName = line.substr(0, pos);
        line.erase(0, pos + 1);

        pos = line.find(",", 0);
        numWaitors = stoi(line.substr(0, pos)); // convert to string
        line.erase(0, pos + 1);

        waitors = new Waitor *[numWaitors];

        for (int j = 0; j < numWaitors - 1; j++)
        {
            pos = line.find(",", 0);
            waitorName = line.substr(0, pos);
            line.erase(0, pos + 1);

            waitors[j] = new Waitor();
            waitors[j]->setName(findWaitor(waitorName)->getName());
            waitors[j]->setPhoneNum(findWaitor(waitorName)->getPhoneNum());
            waitors[j]->setEmail(findWaitor(waitorName)->getEmail());
        }

        int index = numWaitors - 1;
        if (i == numAllRestaurants - 1)
        {
            waitorName = line;
        }
        else
        {
            waitorName = line.substr(0, line.length() - 1);
        }

        waitors[index] = new Waitor();
        waitors[index]->setName(findWaitor(waitorName)->getName());
        waitors[index]->setPhoneNum(findWaitor(waitorName)->getPhoneNum());
        waitors[index]->setEmail(findWaitor(waitorName)->getEmail());

        allRestaurants[i] = new Restaurant();

        allRestaurants[i]->setRestaurantName(restaurantName);
        allRestaurants[i]->setManager(findManager(managerName));
        allRestaurants[i]->setNumWaitors(numWaitors);
        allRestaurants[i]->setMaxReservations(numWaitors);
        allRestaurants[i]->setWaitors(waitors);
        allRestaurants[i]->setReservations();

        // create an empty array of reservations
        // allRestaurants[i].

        i++;
        for (int j = 0; j < numWaitors; j++)
        {
            delete waitors[j];
        }
        delete[] waitors;
        waitors = nullptr;
    }

    file.close();
}

// COMPLETE. WORKS
void printAllRestaurants()
{
    for (int i = 0; i < numAllRestaurants; i++)
    {
        allRestaurants[i]->printRestaurant();
        cout << endl;
    }
}

void clearAllRestaurants()
{
    for (int i = 0; i < numAllRestaurants; i++)
    {
        delete allRestaurants[i];
    }
    delete[] allRestaurants;
    allRestaurants = nullptr;
}

// COMPLETE. WORKS
Restaurant *findRestaurant(string n)
{
    int i = 0;

    while (i < numAllRestaurants)
    {
        if (allRestaurants[i]->getRestaurantName() != n)
        {
            i++;
        }
        else
        {
            return allRestaurants[i];
        }
    }

    return nullptr;
}

bool isReservationEligible(string restaurantChoice, string waitorChoice, int date, bool isDepositPaid)
{
    if (findRestaurant(restaurantChoice) == nullptr)
    {
        cout << restaurantChoice << "is not a restaurant you can make a reservation at." << endl;
        return false;
    }

    if (findWaitor(waitorChoice) == nullptr)
    {
        cout << waitorChoice << "is not a waitor that works at the restaurant." << endl;
        return false;
    }

    if (date < 0 || date > 31)
    {
        cout << date << "is invalid." << endl;
        return false;
    }

    if (!isDepositPaid)
    {
        cout << "You have not paid the deposit." << endl;
        return false;
    }

    return true;
}

void displayReservationConfirmation(Reservation *r)
{
    cout << "You have successfuly made a reservation." << endl;
    r->viewReservation();
}

string customerMakeReservation(Customer *customer)
{
    string restaurantChoice, waitorChoice, result;
    int date, tableNum, numPatrons;
    double depositAmount;
    bool isDepositPaid, isReservationEligible;

    cout << "Available restaurants: " << endl;
    for (int i = 0; i < numAllRestaurants; i++)
    {
        cout << "\t" << i + 1 << allRestaurants[i]->getRestaurantName() << endl;
    }
    cout << "Enter the name of the restaurant: ";
    cin >> restaurantChoice;

    Restaurant *ptrRestaurant = findRestaurant(restaurantChoice);
    Waitor **ptrWaitors = ptrRestaurant->getWaitors();

    cout << "Available waitors: " << endl;
    for (int i = 0; i < ptrRestaurant->getNumWaitors(); i++)
    {
        if (ptrRestaurant->getReservations()[i] == nullptr)
        {
            cout << "\t" << i + 1 << ptrWaitors[i]->getName() << endl;
        }
    }
    cout << "Enter the name of the waitor you would preffer: ";
    cin >> waitorChoice;

    cout << "Enter date: ";
    cin >> date;

    cout << "Enter number of people that will be present: ";
    cin >> numPatrons;

    depositAmount = tableNum * DEPOSIT_PP;

    cout << "The deposit amount is " << depositAmount << "\nHave you paid the deposit.\nEnter true or false: ";
    cin >> isDepositPaid;

    if (!isReservationEligible(restaurantChoice, waitorChoice, date, isDepositPaid))
    {
        return "The information entered is not eligible for an appropriate reservation";
    }

    for (int i = 0; i < ptrRestaurant->getNumWaitors(); i++)
    {
        if (waitorChoice == findWaitor(waitorChoice).getName())
        {
            tableNum = i;
        }
    }

    Reservation *reservation = new Reservation;
    reservation->setRestaurantName(restaurantChoice);
    reservation->setDate(date);
    reservation->setTableNum(tableNum);
    reservation->setNumPatrons(numPatrons);
    reservation->setDepositAmount(depositAmount);
    reservation->setIsDepositPaid(isDepositPaid);
    reservation->setWaitor(findWaitor(waitorChoice));
    reservation->setCustomer(customer);

    displayReservationConfirmation();
    // isRese
    // assign table num to waitor index
}