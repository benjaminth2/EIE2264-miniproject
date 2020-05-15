#include <fstream>
#include <string>
#include <iostream>
#include "Header.h"

using namespace std;

int main() {
	ifstream filein("output.txt", ios::beg);
	ofstream fileout("output.dat",ios::binary);
	char* newChar = new char;
	EngWord* newclass = new EngWord;
	do
	{
		char* charin = newChar;
		filein.getline(charin, 5);
		EngWord* ClassToWrite = newclass;
		ClassToWrite->SetEngWord(charin);
		fileout.write(reinterpret_cast<char*>(ClassToWrite), sizeof(EngWord));

	} while (!filein.eof());
	fileout.close();
	return 0;
}