#ifndef _CAR_
#define _CAR_

#include <iostream>
using namespace std;



class Ccar
{
private:
    string strMake;
    string strModel;
    int intYear;
    double doublePrice;


public:

    Ccar(string="", string="", int=2020, double=20000);



    // setters
    void setMake(string);
    void setModel(string);
    void setYear(int);
    void setPrice(double);

    // getters
    string getMake();
    string getModel();
    int getYear();
    double getPrice();


    friend ostream& operator<<(ostream& out, Ccar& param);
};

#endif
