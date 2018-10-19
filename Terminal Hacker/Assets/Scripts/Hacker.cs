using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		ShowMainMenu();
		
	}

	void ShowMainMenu() {
		Terminal.ClearScreen();
		string greeting = "Hello Wade"
		Terminal.WriteLine(greeting);
		Terminal.WriteLine("What would you like to hack into?\n");
		Terminal.WriteLine("Press 1 for the school.");
		Terminal.WriteLine("Press 2 for Google.");
		Terminal.WriteLine("Press 3 for SpaceX.\n");
		Terminal.WriteLine("Enter your selection:");
	}

	void OnUserInput(string input)
	{
		if (input == "1") {
			Terminal.WriteLine("You chose level 1");
		} else if (input == "2") {
			Terminal.WriteLine("You chose level 2"); 
		} else if (input == "3") {
			Terminal.WriteLine("You chose level 3");
		} else if (input == "menu") {
			ShowMainMenu();
		} else if (input == "007") {
			Terminal.WriteLine("Please choose a valid level Mr. Bond");
		} else {
			Terminal.WriteLine("Please choose a valid level");
		}
	}
}
