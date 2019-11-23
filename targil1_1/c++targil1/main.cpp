//Yishaya Zobel 325889160  
#include "Rational.h"

int main()
{
	int top, bottom;
	char a;
	cout << "enter 2 rational numbers" << endl;
	//getting num1
	if (!(cin >> top >> a >> bottom))
	{
		cout << "ERROR";
		return 1;
	}

	if (a != '/' || !top)
	{
		cout << "ERROR";
		return 1;
	}
	Rational num1(top, bottom);
	
	//getting num2
	if (!(cin >> top >> a >> bottom) || a != '/' || !top) //checking the input is valid
	{
		cout << "ERROR";
		return 1;
	}

	if (a != '/' || !top)
	{
		cout << "ERROR";
		return 1;
	}
	Rational num2(top, bottom);

	bool answer=num1.Rational::equal(num2);//checking if the numbers are equal
	if (answer)
	{
		cout << "equal" <<endl;
	}

	else
	{
		cout << "different ";
		num1.Rational::print();
		cout << " ";
		num2.Rational::print();
		cout << endl;
	}
	cin >> top;
	return 0;
}