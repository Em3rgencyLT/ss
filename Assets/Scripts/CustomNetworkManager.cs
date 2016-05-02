using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

public class CustomNetworkManager : NetworkManager {

	private InputField ipField;

	public void StartupServer()
	{
		NetworkManager.singleton.networkPort = 1314;
		NetworkManager.singleton.StartServer();
		Console.WriteLine("Server running.");
	}

	public void JoinServer()
	{
		ipField = GameObject.Find("InputAddress").GetComponent<InputField>();	
		NetworkManager.singleton.networkAddress = ipField.text;
		NetworkManager.singleton.networkPort = 1314;
		NetworkManager.singleton.StartClient();
		Debug.Log("Joining server...");
	}
}
