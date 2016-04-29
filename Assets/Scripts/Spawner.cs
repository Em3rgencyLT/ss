using UnityEngine;
using UnityEngine.Networking;
using System;

public class Spawner : NetworkBehaviour {

	[SerializeField]
	public GameObject playerPrefab = null;

	public void SpawnPlayerOnServer(NetworkConnection conn)
     	{
        	GameObject playerObj = (GameObject)GameObject.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
         	NetworkServer.AddPlayerForConnection(conn, playerObj, 0);
     	}

	[ClientRpc]
	public void RpcSpawnPlayerOnClient()
	{
		GameObject.Instantiate(gameObject, Vector3.zero, Quaternion.identity);
	}
}
