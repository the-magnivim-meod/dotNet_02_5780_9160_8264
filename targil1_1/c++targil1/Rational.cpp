#include "Rational.h"

Rational::Rational(int m, int n)
{
	mone = m;
	if (n != 0)
	{
		mechane = n;
	}
	else
		mechane = 1;
}

void Rational::set_mone(int m)
{
	mone = m;
	reduction();
}

void Rational::set_mechane(int m)
{
	if (m =! 0)
	{
		mechane = m;
	}	
	reduction();
}

int Rational::get_mone()
{
	return mone;
}

int Rational::get_mechane()
{
	return mechane;
}

void Rational::print()
{
	cout << mone << "/" << mechane;
}

bool Rational::equal(Rational a)
{
	if ((mone == a.get_mone()) && (mechane == a.get_mechane()))
	{
		return true;
	}
	else
	{
		return false;
	}
}

void Rational::reduction()//we divide by all of the numbers we can divide with starting with 2. we divide by each number as many times as we can
{
 	int i = 2;
	
	if (mone > mechane)
	{
		while (i <= mechane)
		{
			if (mone % i == 0 && mechane % i == 0)
			{
				mone /= i;
				mechane /= i;
			}
			else
			{
				i++;
			}
		}
	}
	else if (mone == mechane)
	{
		mone = 1;
		mechane = 1;
	}
	else
	{
		while (i <= mone)
		{
			if (mone % i == 0 && mechane % i == 0)
			{
				mone /= i;
				mechane /= i;
			}
			else
			{
				i++;
			}
		}
	}
}