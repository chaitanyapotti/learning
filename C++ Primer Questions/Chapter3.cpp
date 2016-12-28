#include "stdafx.h"
#include <iostream>
using namespace std;
void Limits();
void Example1();
void Example2_3();
void Chapter3()
{
	//Limits();
	//Example1();
	Example2_3();
}
void Limits()
{
	cout << "char is " << sizeof(char) << endl;
	cout << "short is " << sizeof(short) << endl;
	cout << "int is " << sizeof(int) << endl;
	cout << "long is " << sizeof(long) << endl;
	cout << "long long is " << sizeof(_Longlong) << endl;
	int wrens(432);
	cout << hex;
	cout << "wrens in hex is " << wrens << endl;
	printf("%i \n", wrens);
	char a(65);
	cout << a << endl;
	cout << "Hello\b world" << endl;
	cout << "Enter the code: ______ \b\b\b\b\b\b\b";
	long code;
	cin >> code;
	cout.setf(ios_base::fixed, ios_base::floatfield);
	float tub(10.0 / 3.0);
	double tubx(10.0 / 3.0);
	cout << tub*1e6 << endl;
	cout << tubx*1e15<< endl;
	cout << dec;
	cout.setf(ios_base::fixed, ios_base::floatfield);
	cout << 20.0 * 5 + 24 * 5;
	cin.get();
}

void Example1()
{
	int inches;
	const int Factor = 12;
	cout << "Enter your height in inches (Integer only): _____\b\b\b\b\b";
	cin >> inches;
	int feetValue = inches / Factor;
	int inchValue = inches%Factor;
	cout << endl << "The required value is " << feetValue << " ft and " << inchValue << " in." << endl;
}

void Example2_3()
{
	int yams[3] = { 1,2,3 };
	cout << sizeof(yams)<<" bytes"<<endl;

}