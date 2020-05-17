//CHEUNG Tin Ho Benjamin, 19073365D
//FONG Cheuk Yin, 19049803D
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
};

class EngWord {
public:
	char* GetEngWord() {
		return EngWord;
	}
private:
	char EngWord[5];
};

class Config {
public:
	Config() {
		conf[0][0] = 15;
		conf[0][1] = 2;
		conf[1][0] = 10;
		conf[1][1] = 3;
		conf[2][0] = 5;
		conf[2][1] = 4;
		conf[3][0] = 0;
		conf[3][1] = 5;
		conf[4][0] = 10;
		conf[4][1] = 0;
		conf[5][0] = 3;
		conf[5][1] = 0;
	}
	int GetConfig(int a, int b) {
		return conf[a][b];
	}
	void SetConfig(int a, int b, int c) {
		conf[a][b] = c;
	}
private:
	int conf[6][2];
};