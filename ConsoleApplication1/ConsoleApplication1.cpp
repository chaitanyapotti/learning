// ConsoleApplication1.cpp : Defines the entry point for the console application.
//
#include "stdafx.h"
//#include "fibonacci.cpp"
#include<stdio.h>
#include<iostream>
using namespace std;

int fibonacci(int num);
void RockPaperScissors();
void Diamond();
void PalindromeCheck();
void RightJustify();
void Shuffle();
void MinShuffles();
void SieveOfEratosthenes();
void MergeArrays();
void PascalTriangle();
int main()
{
	//RockPaperScissors();
	//Diamond();
	//PalindromeCheck();
	//Shuffle();
	//MinShuffles();
	//SieveOfEratosthenes();
	//MergeArrays();
	PascalTriangle();
	/*cout << "Hello world.! \n";

	int i = 0;

	while (i <= 10)
	{
		if (i == 0)
		{
			cout << "N \t 10*N \t 100*N \t 1000*N \n \n";
		}
		else
		{
			cout << i << " \t " << 10 * i << " \t " << 100 * i << " \t " << 1000 * i << " \n";
		}
		i++;
	}*/
	//return 0;
	// Sample code for cpp
	/*int a = 12;
	double b = 24.0;
	double c = a + b;
	double y = 1;
	double i = 2.0;
	while (true)
	{
		double fx = 100.0 * i * i - pow(2, i);
		if (fx < 0)
		{
			y = i;
			break;
		}
		i++;

	}
	cout << y;*/

	//Code for Insertion Sort order n^2
	//int arr[8] = { 10,3,5,9,6,2,7,1 };

	////int foo[8] = {};
	//int key;
	//for (int j = 0; j < 8; j++)
	//{
	//	key = arr[j];
	//	int i = j - 1;
	//	while (i > 0 && arr[i] > key)
	//	{
	//		arr[i + 1] = arr[i];
	//		i = i - 1;

	//	}
	//	arr[i + 1] = key;

	//}
	//for (int j = 0; j < 8; j++)
	//{
	//	cout << arr[j];
	//}

	//Code for XOXO
	/*int num = 8;

	for (int i = 0; i < num; i++)
	{
		if (i % 2 == 0)
		{
			for (int j = 0; j < 4; j++)
			{
				cout << "XO";

			}
		}
		else
		{
			for (int j = 0; j < 4; j++)
			{
				cout << "OX";

			}
		}
		cout << "\n";
	}*/

	////Fibonacci
	//cout << "Enter a number: ";
	//int num;
	//cin >> num;
	//int output = fibonacci(num);
	//cout << output << '\n';

	//Insertion Sort


	cin.get();

}


