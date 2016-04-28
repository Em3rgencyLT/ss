using System;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;
﻿using UnityEngine;

public class S_ConsoleInputManager : MonoBehaviour {

	void Awake () 
	{
		Thread _inputThread = new Thread(_inputFunction);
		_inputThread.Start();
		Console.Clear();
		string topBar = "";
		for(int i = 0; i < Console.WindowWidth; i++)
		{
			topBar += "=";
		}
		Console.WriteLine(topBar);
	}

	private void _inputFunction ()
	{
		string userInput;
		while(true){
			userInput = Console.ReadLine();
			if(userInput.Length > 0){
                switch (userInput.ToLowerInvariant())
                {
                    case "help":
                        PrintHelp();
                        break;
                    case "quit":
                    case "exit":
                    case "stop":
                        QuitApplication();
                        break;
                    default:
                        Console.WriteLine("Command " + userInput + " not found.");
                        PrintHelp();
                        break;
                }
			}
		}
	}

	private void PrintHelp ()
	{
        Console.WriteLine("help - Displays this information text.");
        Console.WriteLine("quit/exit/stop - Shuts down this application.");
    }

	private void QuitApplication ()
	{
		Application.Quit();
	}
}
