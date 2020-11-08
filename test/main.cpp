#include <fstream>
#include <iostream>
#include <string>
#include "Ccar.h"
#include "myException.h"

using namespace std;






int main() {
    int option, i, numberOffCars, year;
    string line, make, model, yearString, priceString;
    double price;
    bool foundIt, loaded = false;
    myException myex = myException(999, "option does not exist"); // using custom exception
    ifstream fin;
    // file exception to be typed here
    try {
        fin.open("car.txt");
        if (fin.fail()) {
            throw 0;
        }
    }
    catch (int e) {
        cout << "file not exist!" << endl;
        exit(1);
    }

    // num of cars counted
    numberOffCars = 0;
    while (fin.good()) //while i have not reached the eof
    {
        getline(fin, line);
        numberOffCars++;
    }
    fin.close();
    //memory allocation
    try {
        Ccar* carList = new Ccar[numberOffCars];

        // Dynamic memory allocation
                //menu
        do {
            int count;
            cout << "1. Load Cars" << endl;
            cout << "2. Display all Cars" << endl;
            cout << "3. Search Cars" << endl;
            cout << "4. Count Cars older than 30 years" << endl;
            cout << "5. Exit" << endl;
            cin >> option;
            try {
                if (option < 1 || option >5)
                {
                    throw myex;
                }
                else
                {
                    switch (option)
                    {
                    case 1: // load
                        loaded = true;
                        fin.open("car.txt");
                        i = 0;
                        while (fin.good())
                        {
                            yearString = "";
                            priceString = "";
                            getline(fin, make, '$');
                            carList[i].setMake(make);
                            getline(fin, model, '$');
                            carList[i].setModel(model);
                            getline(fin, yearString, '$');
                           
                            if (yearString != "")
                                year = stoi(yearString);
                            carList[i].setYear(year);
                            getline(fin, priceString, '\n');
                            if (priceString != "")
                                price = stoi(priceString);
                            carList[i].setPrice(price);
                            if (yearString == "" && priceString == "")
                            {
                                carList[i].setYear(2020);
                                carList[i].setPrice(20000);

                            }
                            else if (priceString == "")
                            {
                                if (year > 2015 && year <= 2020)
                                    carList[i].setPrice(20000);
                                else if (year > 2010 && year <= 2015)
                                    carList[i].setPrice(14000);
                                else if (year > 1980 && year <= 2010)
                                    carList[i].setPrice(7000);
                                else
                                    carList[i].setPrice(400000);
                            }
                            i++; //next car

                        } //end of while
                        fin.close();
                        break;
                    case 2: // display
                        if (loaded)
                        {
                            i = 0;
                            while (i < numberOffCars)
                            {
                                cout << carList[i] << endl;
                                i++; //next car
                            }
                        }
                        break;
                    case 3: // search
                        foundIt = false;
                        if (loaded)
                        {
                            cout << "Enter a car make: " << endl;
                            cin >> make;
                            cout << "Enter a car model: " << endl;
                            cin >> model;
                            i = 0;
                            while (i < numberOffCars)
                            {
                                if (carList[i].getMake() == make && carList[i].getModel() == model)
                                {
                                    cout << carList[i]; // use overloading <<
                                    foundIt = true;
                                }
                                i++; //next car
                            }
                            // search for this make and model
                        }
                        else {
                            cout << "Load the cars first! " << endl;

                        }

                        // check if found
                        if (!foundIt)
                        {
                            cout << "not found" << endl;
                        }

                        foundIt = false;

                        break;

                    case 4: // count the cars older than 30 years
                        i = 0;
                        count = 0;
                        while (i < numberOffCars)
                        {
                            if ((2020 - carList[i].getYear()) > 30)
                            {
                                count += 1; 
                            }
                            i++; //next car
                        }
                        cout << "the number of cars older than 30 years is: " << count << "\n" << endl;
                        break;

                    case 5: // exit

                        cout << "\n\n\t\t\t Thanks for using our aplication" << endl;

                    default: // already handled by cust excep
                        cout << "Invalid option! Try again" << endl;
                        break;
                    } // end of switch

                } // end of try

            }
            catch (myException& ex) {
                cout << "error id:" << ex.getErrorID() << " error message:" << ex.getErrorMsg() << endl;
            }
        } while (option != 5); // 5 exit option
        delete[] carList;
    }
    catch (bad_alloc&)
    {
        cout << "Error in allocating memory" << endl;
    }
    return 0;
}

