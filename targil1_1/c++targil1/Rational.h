#pragma once
#include <iostream>
using namespace std;
class Rational
{
private:
	int mone;
	int mechane;
	void reduction(); 
public:
	Rational(int = 0,int = 1);//CTOR
	void set_mone(int);
	void set_mechane(int);
	int get_mone();
	int get_mechane();
	void print();
	bool equal(Rational);
};