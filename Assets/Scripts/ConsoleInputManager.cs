/*
*   This script is fucking terrified of being on the same object as a NetworkIdentity.
*   Potentially other kinds of objects/scripts too. Unity is known for having a borked Console.
*   If your Console I/O stops working properly, try to put this on its own object to debug.
*/

using System;
using System.Threading;
﻿using UnityEngine;

public class ConsoleInputManager : MonoBehaviour {

    private CustomNetworkManager networkManager;
    private bool needToStartServer;
    private bool needToQuit;

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

    void Start()
    {
        networkManager = GameObject.Find("Custom Network Manager").GetComponent<CustomNetworkManager>();
        needToStartServer = false;
        needToQuit = false;
    }

    void Update()
    {
        if (needToStartServer)
        {
            networkManager.StartupServer();
            needToStartServer = false;
        }
        if (needToQuit)
        {
            Application.Quit();
        }
    }

	private void _inputFunction ()
	{
		string userInput;
		while(true)
		{
			userInput = Console.ReadLine();
			if(userInput.Length > 0)
			{
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

    //Unity doesn't like several things to do with servers running on its own threads
    //So we set booleans, so the main thread (Update()) can do them instead.

    private void StartServer()
	{
        needToStartServer = true;
	}

	private void QuitApplication ()
	{
        needToQuit = true;
	}
}
