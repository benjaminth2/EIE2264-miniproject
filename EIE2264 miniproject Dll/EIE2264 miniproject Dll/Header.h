#include <string>
#include <fstream>

using namespace std;

class PlayerData {
public:
	PlayerData() {
		strcpy_s(playername, "");
		highscore = -1;
	}
	char* GetPlayerName() {
		return playername;
	}
	int GetHighscore() {
		return highscore;
	}
	void SetPlayerName(char* a){
		strcpy_s(playername, a);
	}
	void SetHighScore(int i) {
		highscore = i;
	}
private:
	char playername[50];
	int highscore;
	int highscoremode;
};

class EngWord {
public:
	char* GetEngWord() {
		return EngWord;
	}
private:
	char EngWord[5];
};