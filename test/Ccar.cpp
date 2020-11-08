#include <iostream>
#include "Ccar.h"



Ccar::Ccar(string make, string model, int year, double price) {

    setMake(make);
    setModel(model);
    setYear(year);
    setPrice(price);
}


void Ccar::setMake(string make) {
    strMake = make;
}
void Ccar::setModel(string model) {
    strModel = model;
}

void Ccar::setYear(int year) {
    intYear = year;
}
void Ccar::setPrice(double price) {
    doublePrice = price;
}



// getters

string Ccar::getMake() {
    return strMake;
}
string Ccar::getModel() {
    return strModel;
}
int Ccar::getYear() {
    return intYear;
}
double Ccar::getPrice() {
    return doublePrice;
}



// <<
ostream& operator<<(ostream& out, Ccar& param) {
    out << "make:" << param.getMake() << "model:" << param.getModel() << "price:" << param.getPrice() << "year:" << param.getYear() << "\n";
    return out;
}


