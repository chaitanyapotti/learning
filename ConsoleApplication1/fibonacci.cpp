#include "stdafx.h"
//#include<stdio.h>
#include<iostream>
using namespace std;

//int fibonacci(int num);

int fibonacci(int num)
{
	
	int fibo;
	if (num == 1)
	{
		fibo = 1;
	}
	else if (num == 2)
	{
		fibo = 1;
	}
	else
	{
		fibo = fibonacci(num - 1) + fibonacci(num - 2);
	}
	return fibo;
}