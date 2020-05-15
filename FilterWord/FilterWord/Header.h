#pragma once
#include <string>
#include <fstream>

using namespace std;

class EngWord {
public:
	char* GetEngWord() {
		return EngWord;
	}
	void SetEngWord(char* a) {
		strcpy_s(EngWord, a);
	}
private:
	char EngWord[5];
};