using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Game configuration data
	string[] level1Passwords = {"lunch", "book", "class", "subs", "food", "teacher"};
	string[] level2Passwords = {"youtube", "calendar", "pixel", "android", "python", "drive"};
	string[] level3Passwords = {"falcon", "rocket launch", "space trip", "booster", "visionary", "mars"};


	// Game State
	public int level;
	public enum Screen { MainMenu, Password, Win };
	public Screen currentScreen;
	public string password;

	// Use this for initialization
	void Start () {
		ShowMainMenu();
	}

	void ShowMainMenu() {
		currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		string greeting = "Hello Wade";
		Terminal.WriteLine(greeting);
		Terminal.WriteLine("What would you like to hack into?\n");
		Terminal.WriteLine("Press 1 for the school.");
		Terminal.WriteLine("Press 2 for Google.");
		Terminal.WriteLine("Press 3 for SpaceX.\n");
		Terminal.WriteLine("Enter your selection:");
	}

	void OnUserInput(string input)
	{
		if (input == "menu") { // we can always go back to the main menu
			ShowMainMenu(); 
		} else if (input == "quit" || input == "close" || input == "exit" || input == "Quit" || input == "Close" || input == "Exit") {
			Terminal.WriteLine("If on the web just close the tab");
			Application.Quit();
		} else if (currentScreen == Screen.MainMenu) {
			RunMainMenu(input);
		} else if (currentScreen == Screen.Password) {
			CheckPassword(input);
		}
	}

	void AskForPassword() {
		currentScreen = Screen.Password;
		Terminal.ClearScreen();
		SetRandomPassword();
		Terminal.WriteLine("Enter your password, hint: " + password.Anagram() );
		RestartMessage();
	}

	void SetRandomPassword() {
		int index;
		switch(level) {
			case 1:
				index = Random.Range(0, level1Passwords.Length - 1);
				password = level1Passwords[index];
				break;
			case 2:
				index = Random.Range(0, level2Passwords.Length - 1);
				password = level2Passwords[index];
				break;
			case 3:
				index = Random.Range(0, level3Passwords.Length - 1);
				password = level3Passwords[index];
				break;
			default:
				Debug.LogError("You have chosen an invalid level!");
				RestartMessage();
				break;
		}
	}

	void RunMainMenu(string input) {
		bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

		if (isValidLevelNumber) {
			level = int.Parse(input);
			AskForPassword();
		} else if (input == "007") {
			Terminal.WriteLine("Please choose a valid level Mr. Bond");
			RestartMessage();
		} else {
			Terminal.WriteLine("Please choose a valid level");
			RestartMessage();
		}
	}

	void CheckPassword(string input) {
		if (input == password) {
			DisplayWinScreen();
		} else {
			FailedMessage();
		}
	}

	void DisplayWinScreen() {
		currentScreen = Screen.Win;
		Terminal.ClearScreen();
		ShowLevelReward();
	}

	void ShowLevelReward() {
		switch(level) {
			case 1:
				Terminal.WriteLine("Congratulations you guessed the");
				Terminal.WriteLine("password for level 1!");
				Terminal.WriteLine("Have a book...");
				Terminal.WriteLine(@"
    _______
   /	  //
  /		 //
 /_____ //
(______(/");
				RestartMessage();
				break;
			case 2:
				Terminal.WriteLine("Congratulations you guessed the");
				Terminal.WriteLine("password for level 2!");
				Terminal.WriteLine("You have unlocked...");
				Terminal.WriteLine(@"
   ______                      __    
  / ____/____   ____   ____ _ / /___ 
 / / __ / __ \ / __ \ / __ `// // _ \
/ /_/ // /_/ // /_/ // /_/ // //  __/
\____/ \____/ \____/ \__, //_/ \___/ 
                    /____/");
				RestartMessage();
				break;
			case 3:
				Terminal.WriteLine("Congratulations you guessed the");
				Terminal.WriteLine("password for level 3!");
				Terminal.WriteLine("You have unlocked...");
				Terminal.WriteLine(@"                       
 ___  _ __    __ _   __  ___ __  __
/ __|| '_ \  / _` | / _|/ _ \\ \/ /
\__ \| |_) || (_| || (_|  __/ >  <
|___/| .__/  \__,_| \__|\___|/_/\_\
     |_|");
				RestartMessage();
				break;
			default:
				Debug.LogError("You won a level that doesn't exist");
				break;
		}
		
	}

	void FailedMessage() {
		Terminal.WriteLine("Sorry you guessed incorrectly try again.");
	}

	void RestartMessage() {
		Terminal.WriteLine("Please type 'menu' to restart the game");
	}
}
