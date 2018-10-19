using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		ShowMainMenu("Wade");
		
	}

	void ShowMainMenu(string greeting) {
		Terminal.ClearScreen();
		greeting = "Hello " + greeting;
		Terminal.WriteLine(greeting);
		Terminal.WriteLine("What would you like to hack into?\n");
		Terminal.WriteLine("Press 1 for the school.");
		Terminal.WriteLine("Press 2 for Google.");
		Terminal.WriteLine("Press 3 for SpaceX.\n");
		Terminal.WriteLine("Enter your selection:");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
