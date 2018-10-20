using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Game State
	int level;
	enum Screen { MainMenu, Password, Win }
	Screen currentScreen;
	string password;

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
		} else if (currentScreen == Screen.MainMenu) {
			RunMainMenu(input);
		} else if (currentScreen == Screen.Password) {
			CheckPassword(input);
		}
	}

	void StartGame() {
		currentScreen = Screen.Password;
		Terminal.WriteLine("You chose level " + level);
		Terminal.WriteLine("Please enter your password: ");
	}

	void RunMainMenu(string input) {
		if (input == "1") {
			level = 1;
			password = "easy";
			StartGame();
		} else if (input == "2") {
			level = 2;
			password = "medium";
			StartGame();
		} else if (input == "3") {
			level = 3;
			password = "difficult";
			StartGame();
		} else if (input == "007") {
			Terminal.WriteLine("Please choose a valid level Mr. Bond");
		} else {
			Terminal.WriteLine("Please choose a valid level");
		}
	}

	void CheckPassword(string input) {
		if (input == password) {
			SuccessMessage();
		} else {
			FailedMessage();
		}
		// if (level == 1) {
		// 	if (input == "easy") {
		// 		SuccessMessage();
		// 	} else {
		// 		FailedMessage();
		// 	}
		// } else if (level == 2) {
		// 	if (input == "medium") {
		// 		SuccessMessage();
		// 	} else {
		// 		FailedMessage();
		// 	}
		// } else if (level == 3) {
		// 	if (input == "difficult") {
		// 		SuccessMessage();
		// 	} else {
		// 		FailedMessage();
		// 	}
		// }
	}

	void SuccessMessage() {
		Terminal.WriteLine("Congratulations you guessed the password!");
	}

	void FailedMessage() {
		Terminal.WriteLine("Sorry you guessed incorrectly try again.");
	}
}
