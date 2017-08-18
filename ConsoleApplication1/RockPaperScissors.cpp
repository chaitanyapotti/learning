#include "stdafx.h"
#include<iostream>
#include <cstdlib>
#include <iomanip>
#include <string>
#include <fstream>
using namespace std;

enum Result { User, Computer, Tie };

enum Choice { Rock, Paper, Scissor };

bool isPalindrome(string s);
bool isSorted(int* a, int n);
void RockPaperScissors()
{
	Choice user, computer;
	Result result;
	char userEntry;
	cout << "Enter {R/S/P} : ";
	cin >> userEntry;
	switch (userEntry)
	{
	case 'R':
		user = Rock;
		break;
	case 'S':
		user = Scissor;
		break;
	case 'P':
		user = Paper;
		break;
	default:
		user = Rock;
		break;
	}
	int comupterEntry = rand();
	switch (comupterEntry % 3)
	{
	case 1:
		computer = Rock;
		break;
	case 2:
		computer = Scissor;
		break;
	case 0:
		computer = Paper;
		break;
	default:
		computer = Rock;
		break;
	}

	if (computer == user) result = Tie;
	else if ((computer == Rock && user == Scissor) || (computer == Scissor && user == Paper) || (computer == Paper && user == Rock)) result = Computer;
	else result = User;

	cout << "The computer chose " << computer << " .The user chose " << user << " . The result is " << result;
}

void Diamond()
{
	int N = 3;
	for (size_t i = 0; i <= 2 * N; i++)
	{
		if (i < N)
		{
			for (size_t j = 0; j <= 2 * N; j++)
			{
				if (j < N - i || j > N + i) cout << ' ';
				else cout << '*';
			}
		}
		else
		{
			for (size_t j = 0; j <= 2 * N; j++)
			{
				if (j < i - N || j > 3 * N - i) cout << ' ';
				else cout << setiosflags(ios::fixed | ios::showpoint) << setprecision(2) << '*';
			}
		}
		cout << endl;
	}
}

void PalindromeCheck()
{
	cout << "Enter a string: ";
	string s;
	while (getline(cin, s))
	{
		cout << "The string is \"" << s;
		if (isPalindrome(s)) cout << "\" is a palindrome \n";
		else cout << "\" is not a palindrome \n";
		cout << "Enter another string : ";
	}
}
bool isPalindrome(string s)
{
	int n = s.length();
	int* n1 = &n;
	int n2 = *n1;
	int& n3 = n;
	n3 /= 2;
	string* s2 = new string("goodbye");
	string s3 = *s2;
	delete s2;
	string a2[] = { "1", "@", "2" };

	string* child = new string[n];
	child[0] = "sq";
	child[1] = "wq";
	for (size_t i = 0; i < n; i++)
	{
		if (toupper(s[i]) != toupper(s[n - 1 - i])) return false;
	}
	delete child;
	int n4 = 1;
	return true;
}

void RightJustify()
{
	ifstream inputFile("Bloopers.txt");
	ofstream outputFile("vb.txt");
	string str;
	const int width = 60;
	while (getline(inputFile, str))
	{
		outputFile << string(width - str.length(), ' ') << str << endl;
	}
}

void Shuffle()
{
	int n = 9;
	int arr[] = { 1,2,3,4,5,6,7,8,9 };
	int* temp = new int[n];
	int max = (n % 2 == 0) ? n / 2 : n / 2 + 1;
	for (size_t i = 0; i < max; i++)
	{
		temp[2 * i] = arr[n / 2 + i];
		temp[2 * i + 1] = arr[i];
	}
	for (size_t i = 0; i < n; i++)
	{
		cout << temp[i] << ' ';
	}
}

void Shuffle(int* arr, int n)
{
	int* temp = new int[n];
	int max = (n % 2 == 0) ? n / 2 : n / 2 + 1;
	for (size_t i = 0; i < max; i++)
	{
		temp[2 * i] = arr[n / 2 + i];
		temp[2 * i + 1] = arr[i];
	}
	for (size_t i = 0; i < n; i++)
	{
		arr[i] = temp[i];
	}
}

void MinShuffles()
{
	int arr[] = { 5,1,6,2,7,3,8,4 };
	int count = 0;
	int n = 8;
	while (!isSorted(arr, n))
	{
		Shuffle(arr, n); count++;
	}
	cout << count;
}

bool isSorted(int* a, int n)
{
	for (size_t i = 1; i < n; i++)
	{
		if (a[i] < a[i - 1]) return false;
	}
	return true;
}

void SieveOfEratosthenes()
{
	const int n = 1000;
	bool arr[n] = { false };
	arr[2] = arr[3] = true;
	for (size_t i = 5; i < n; i += 2)
	{
		arr[i] = true;
		double sqtn = sqrt(i);
		for (size_t j = 3; j <= sqtn; j++)
		{
			if (i % j == 0) { arr[i] = false; break; }
		}
	}

	for (size_t i = 0; i < n; i += 1)
	{
		if (arr[i]) cout << setw(5) << i;
	}

}

void MergeArrays()
{
	/*int a[] = { 1,2,3,4,5,6,7,8,9 };
	int b[] = { 5,6,7,8,9,10,11,12,13 };
	int m = 9, n = 9;*/
	int a[] = { 11,44,55,88, 111 };
	int b[] = { 22,33,66,77,99 };
	int m = 5, n = 5;
	int* temp = new int[m + n];
	int i = 0, j = 0;
	for (int k = 0; k < m + n; k++)
	{
		if (i >= m || j >= n) break;
		temp[k] = a[i] < b[j] ? a[i++] : b[j++];
		cout << temp[k] << " ";
	}
	for (int k = i + j; k < m + n; k++)
	{
		temp[k] = i >= m ? b[j++] : a[i++];
		cout << temp[k] << " ";
	}
}

void PascalTriangle()
{
	const int N = 12;
	int c[N][N];
	for (size_t i = 0; i <= N; i++)
	{
		c[i][0] = c[i][i] = 1;
	}
	for (size_t i = 2; i <= N; i++)
	{
		for (size_t j = 1; j < i; j++)
		{
			c[i][j] = c[i - 1][j] + c[i - 1][j - 1];
		}
	}
	for (size_t i = 0; i <= N; i++)
	{
		cout << "\n" << string(2 * (N - i), ' ');
		for (size_t j = 0; j <= i; j++)
		{
			cout << setw(4) << c[i][j];
		}
	}
}