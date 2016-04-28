using System;
﻿using UnityEngine;
using UnityEngine.Networking;

public class S_NetworkManager : MonoBehaviour {

	void Start () 
	{
		NetworkServer.Listen(1314);
		Console.WriteLine("Server started.");

        NetworkServer.RegisterHandler(MsgType.Connect, OnConnected);
        NetworkServer.RegisterHandler(MsgType.Disconnect, OnDisconnected);
	}

    private void OnConnected (NetworkMessage netMsg)
    {
        Console.WriteLine("Client from " + netMsg.conn.address + " connected.");
        //TODO: store and handle connected player data
    }

    private void OnDisconnected (NetworkMessage netMsg)
    {
        Console.WriteLine(netMsg.conn.address + " disconnected.");
        //TODO: handle player disconnect
    }
}
