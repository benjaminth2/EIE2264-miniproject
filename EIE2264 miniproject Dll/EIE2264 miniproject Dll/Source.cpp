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
	filein.getline(str, 50);
	ofstream clrfile("ans.txt", ios::trunc);
	clrfile.close();
	return str;
}

void AppPlayerData(PlayerData* ClassToWrite) {
	ofstream fileout("players.dat", ios::app|ios::binary);
	fileout.write(reinterpret_cast<char*>(ClassToWrite), sizeof(PlayerData));
	fileout.close();
}

void ModPlayerData(PlayerData* ClassToWrite,int loc) {
	ofstream fileout("players.dat", ios::beg | ios::binary);
	fileout.seekp(loc * sizeof(PlayerData));
	fileout.write(reinterpret_cast<char*>(ClassToWrite), sizeof(PlayerData));
	fileout.close();
}

PlayerData* ReadPlayerData(int loc) {
	PlayerData* Player = new PlayerData;
	ifstream filein("players.dat", ios::binary | ios::beg);
	filein.seekg(loc * sizeof(PlayerData));
	filein.read(reinterpret_cast<char*>(Player), sizeof(PlayerData));
	filein.close();
	return Player;
}

int GetTotalNumberOfPlayer() {
	ifstream filein("players.dat", ios::binary | ios::ate);
	return filein.tellg() / sizeof(PlayerData) + 1;
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
		for (int i = 0; name[i] != 0; i++)
		{
			if (player->GetPlayerName()[i] != readfromtempfile()[i])
			{
				match = false;
			}
		}
		if (match)
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

int GetRandomNumber() {
	srand(GetTickCount());
	return rand();
}

int ChkChi() {
	ifstream filein("Chi_Ans.txt", ios::beg);
	char* newChar = new char;
	char* UserAns = readUserAnswer();
	do
	{
		char* charin = newChar;
		filein.getline(charin, 255);
		
		if (strcmp(UserAns,charin) == 0) {
			return 1;
		}

	} while (!filein.eof());
	return 0;
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
	__declspec(dllexport) int __stdcall dllGetRandomNumber() {
		return GetRandomNumber();
	}
	__declspec(dllexport) int __stdcall dllChkChi() {
		return ChkChi();
	}
}