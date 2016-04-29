using System;
using System.Threading;
﻿using UnityEngine;

public class ConsoleInputManager : MonoBehaviour {

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
		PrintHelp();
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
					case "start":
						StartServer();
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
		Console.WriteLine("start - Start the server.");
        Console.WriteLine("quit/exit/stop - Shuts down this application.");
    }
	
	private void StartServer()
	{
		CustomNetworkManager networkManager = GameObject.Find("Custom Network Manager").GetComponent<CustomNetworkManager>();
		networkManager.StartServer();
	}

	private void QuitApplication ()
	{
		Application.Quit();
	}
}
