#include "stdafx.h"
#include <iostream>
using namespace std;
void furlong();
void BlindMice();
void Run();
void Example2();
void Example3();
void Chapter2()
{
	
	/*int number;
	cout << "Hello World \n";
	cout << "Enter the number of carrots: ";
	cin >> number;
	cout << endl <<"You have " << ++number << " carrots after the transcation" <<endl;*/
	//cin.get();
	//Example2();
	Example3();
}

void furlong()
{
	double furlongs;
	cout << "Tell me the distance in furlongs: ";
	cin >> furlongs;
	cout << "The value in yards = " << furlongs * 220 << endl;
}

void BlindMice()
{
	cout << "Three blind mice \n";
}
void Run()
{
	cout << "See how they run \n";
}
void Example2()
{
	furlong();
}
void Example3()
{
	BlindMice();
	BlindMice();
	Run();
	Run();
}