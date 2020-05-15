#include "Header.h"
#include <string>
#include <fstream>
#include <time.h>
#include <windows.h>

using namespace std;

char* readfromtempfile() {
	char* str = new char;
	ifstream filein("temp.txt", ios::beg);
	filein.getline(str, 50);
	return str;
}

char* readUserAnswer() {
	char* str = new char;
	ifstream filein("ans.txt", ios::beg);
	filein.getline(str, 5);
	ofstream clrfile("ans.txt", ios::trunc);
	clrfile.close();
	return str;
}

int GetTotalNumberOfPlayer() {
	ifstream filein("players.dat", ios::binary);
	filein.seekg(0, ios::end);
	return (filein.tellg() / sizeof(PlayerData));
}

void AppPlayerData(PlayerData* ClassToWrite) {
	ofstream fileout("players.dat", ios::app | ios::binary);
	fileout.seekp(GetTotalNumberOfPlayer() * sizeof(PlayerData));
	fileout.write(reinterpret_cast<char*>(ClassToWrite), sizeof(PlayerData));
	fileout.close();
}

void ModPlayerData(PlayerData* ClassToWrite,int loc) {
	fstream file("players.dat", ios::binary | ios::in | ios::out);
	file.seekp(loc * sizeof(PlayerData),ios::beg);
	file.write(reinterpret_cast<char*>(ClassToWrite), sizeof(PlayerData));
	file.close();
}

PlayerData* ReadPlayerData(int loc) {
	PlayerData* Player = new PlayerData;
	ifstream filein("players.dat", ios::binary | ios::beg);
	filein.seekg(loc * sizeof(PlayerData));
	filein.read(reinterpret_cast<char*>(Player), sizeof(PlayerData));
	filein.close();
	return Player;
}

void CreateNewPlayer() {
	PlayerData* newPlayer = new PlayerData;
	newPlayer->SetHighScore(0);
	newPlayer->SetPlayerName(readfromtempfile());
	AppPlayerData(newPlayer);
}

int FindPlayerInList() {
	int length = GetTotalNumberOfPlayer();
	PlayerData* player;
	char* name = readfromtempfile();
	for (int i = 0; i < length; i++)
	{
		player = ReadPlayerData(i);
		bool match = true;
		if (strcmp(player->GetPlayerName(), name) == 0)
		{
			return i;
		}
	}
	CreateNewPlayer();
	return -1;
}

int HighScoreOfPlayer() {
	return ReadPlayerData(FindPlayerInList())->GetHighscore();
}

void UpdateHighScore(int Score) {
	PlayerData* Player = ReadPlayerData(FindPlayerInList());
	if (Score > Player->GetHighscore())
	{
		Player->SetHighScore(Score);
		ModPlayerData(Player, FindPlayerInList());
	}
}

void EditHighScore(int Score) {
	PlayerData* Player = ReadPlayerData(FindPlayerInList());
	Player->SetHighScore(Score);
	ModPlayerData(Player, FindPlayerInList());
}

int GetRandomNumber() {
	srand(GetTickCount());
	return rand();
}

int ChkChi() {
	ifstream filein("ChiDict.txt", ios::beg);
	char* newChar = new char;
	char* UserAns = readUserAnswer();
	do
	{
		char* charin = newChar;
		filein.getline(charin, 5);
		
		if (strcmp(UserAns,charin) == 0) {
			return 1;
		}

	} while (!filein.eof());
	return 0;
}


void WriteCountryToAns() {
	ifstream filein("CountryDict.dat", ios::ate | ios::binary);
	filein.seekg(GetRandomNumber() % (filein.tellg() / sizeof(EngWord)) * sizeof(EngWord));
	EngWord* Eng = new EngWord;
	filein.read(reinterpret_cast<char*>(Eng), sizeof(EngWord));
	filein.close();
	ofstream fileout("ans.txt", ios::trunc);
	fileout << Eng->GetEngWord();
	fileout.close();
}

void WriteEngToAns() {
	ifstream filein("EngDict.dat", ios::ate | ios::binary);
	filein.seekg(GetRandomNumber() % (filein.tellg() / sizeof(EngWord)) * sizeof(EngWord));
	EngWord* Eng = new EngWord;
	filein.read(reinterpret_cast<char*>(Eng), sizeof(EngWord));
	filein.close();
	ofstream fileout("ans.txt",ios::trunc);
	fileout << Eng->GetEngWord();
	fileout.close();
}

int ChkCountry() {
	ifstream filein("CountryDict.dat", ios::beg | ios::binary);
	char* UserAns = readUserAnswer();
	char* newChar = new char;
	EngWord* Eng = new EngWord;
	for (int i = 0; i < 7186; i++)
	{
		filein.seekg(i * sizeof(EngWord));
		filein.read(reinterpret_cast<char*>(Eng), sizeof(EngWord));
		if (strcmp(Eng->GetEngWord(), UserAns) == 0)
		{
			return 1;
		}
	}
	return 0;
}

int ChkEng() {
	ifstream filein("EngDict.dat", ios::beg | ios::binary);
	char* UserAns = readUserAnswer();
	char* newChar = new char;
	EngWord* Eng = new EngWord;
	for (int i = 0; i < 7186; i++)
	{
		filein.seekg(i * sizeof(EngWord));
		filein.read(reinterpret_cast<char*>(Eng), sizeof(EngWord));
		if (strcmp(Eng->GetEngWord(),UserAns) == 0)
		{
			return 1;
		}
	}
	return 0;
}

void Sort() {
	PlayerData* temp = new PlayerData;
	PlayerData* JPtr = new PlayerData;
	int k = GetTotalNumberOfPlayer();

	fstream file("players.dat", ios::binary | ios::in | ios::out);
	for (int i = 1; i < k; i++)
	{
		file.seekg(i * sizeof(PlayerData));
		file.read(reinterpret_cast<char*>(temp), sizeof(PlayerData));
		file.seekg((i - 1) * sizeof(PlayerData));
		file.read(reinterpret_cast<char*>(JPtr), sizeof(PlayerData));

		for (int j = i - 1; j >= 0 && JPtr->GetHighscore() > temp->GetHighscore(); j--)
		{
			file.seekp((j + 1) * sizeof(PlayerData));
			file.write(reinterpret_cast<char*>(JPtr), sizeof(PlayerData));
			file.seekp(j * sizeof(PlayerData));
			file.write(reinterpret_cast<char*>(temp), sizeof(PlayerData));
			file.seekg((j - 1) * sizeof(PlayerData));
			file.read(reinterpret_cast<char*>(JPtr), sizeof(PlayerData));
		}
	}
	file.close();
}

int ScoreBoard(int RecordNum) {
	PlayerData* player = ReadPlayerData(GetTotalNumberOfPlayer() - RecordNum);
	ofstream fileout("ans.txt" , ios::trunc);
	fileout << player->GetPlayerName();
	fileout.close();
	return player->GetHighscore();
}

void editconfig(int a, int b, int c) {
	ifstream filein("config.dat", ios::binary);
	filein.seekg(0);
	Config* cfg = new Config;
	filein.read(reinterpret_cast<char*>(cfg), sizeof(Config));
	filein.close();
	cfg->SetConfig(a, b, c);
	ofstream fileout("config.dat", ios::binary|ios::trunc);
	fileout.seekp(0);
	fileout.write(reinterpret_cast<char*>(cfg), sizeof(Config));
	fileout.close();
}

int getconfig(int a, int b) {
	ifstream filein("config.dat", ios::binary);
	filein.seekg(0);
	Config* cfg = new Config;
	filein.read(reinterpret_cast<char*>(cfg), sizeof(Config));
	filein.close();
	return cfg->GetConfig(a, b);
}
extern "C"
{
	__declspec(dllexport) int __stdcall dllFindPlayerInList() {
		return FindPlayerInList();
	}
	__declspec(dllexport) int __stdcall dllHighScoreOfPlayer() {
		return HighScoreOfPlayer();
	}
	__declspec(dllexport) void __stdcall dllUpdateHighScore(int score) {
		UpdateHighScore(score);
	}
	__declspec(dllexport) void __stdcall dllEditHighScore(int score) {
		EditHighScore(score);
	}
	__declspec(dllexport) int __stdcall dllGetRandomNumber() {
		return GetRandomNumber();
	}
	__declspec(dllexport) int __stdcall dllChkChi() {
		return ChkChi();
	}
	__declspec(dllexport) int __stdcall dllChkEng() {
		return ChkEng();
	}
	__declspec(dllexport) void __stdcall dllWriteEngToAns() {
		WriteEngToAns();
	}
	__declspec(dllexport) void __stdcall dllSort() {
		Sort();
	}
	__declspec(dllexport) int __stdcall dllChkCountry() {
		return ChkCountry();
	}
	__declspec(dllexport) void __stdcall dllWriteCountryToAns() {
		WriteCountryToAns();
	}
	__declspec(dllexport) int __stdcall dllGetTotalNumberOfPlayer() {
		return GetTotalNumberOfPlayer();
	}
	__declspec(dllexport) int __stdcall dllScoreBoard(int loc) {
		return ScoreBoard(loc);
	}
	__declspec(dllexport) void __stdcall dlleditconfig(int a,int b,int c) {
		editconfig(a, b, c);
	}
	__declspec(dllexport) int __stdcall dllgetconfig(int a,int b) {
		return getconfig(a,b);
	}
	
}