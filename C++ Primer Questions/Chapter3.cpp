#include "stdafx.h"
#include <iostream>
using namespace std;
void Limits();
void Chapter3()
{
	Limits();
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
}