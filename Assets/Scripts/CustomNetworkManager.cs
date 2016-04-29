﻿using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Net;

public class CustomNetworkManager : MonoBehaviour {

	public NetworkClient myClient;	

	public void StartServer()
	{
		NetworkServer.Listen(1314);

		NetworkServer.RegisterHandler(MsgType.Connect, OnAClientConnected);
        NetworkServer.RegisterHandler(MsgType.Disconnect, OnAClientDisconnected);

		Console.WriteLine("Server started.");
	}

	public void ConnectToServer(string address)
	{
		myClient = new NetworkClient();
        string lookup = HostnameLookup(address);
        if(lookup.Length > 0)
        {
            myClient.Connect(lookup, 1314);
        }
        else
        {
            Application.Quit();
        }
	}

    private void OnAClientConnected (NetworkMessage netMsg)
    {
        Console.WriteLine("Client from " + netMsg.conn.address + " connected.");
        //GameObject gameManager = GameObject.Find("Game Manager");
        //Spawner spawner = gameManager.GetComponent<Spawner>();
		//spawner.SpawnPlayerOnServer(netMsg.conn);
		//spawner.RpcSpawnPlayerOnClient();
        //TODO: store and handle connected player data
    }
	
    private void OnAClientDisconnected (NetworkMessage netMsg)
    {
        Console.WriteLine(netMsg.conn.address + " disconnected.");
        //TODO: handle player disconnect
    }

    private string HostnameLookup (string hostname)
    {
	    IPHostEntry host;
		try
		{
	    	host = Dns.GetHostEntry(hostname);
		}
		catch (System.Net.Sockets.SocketException e)
		{
	    	Debug.LogError(e);
	    	return "";
		}
		return host.AddressList[0].ToString();
    	}
}
