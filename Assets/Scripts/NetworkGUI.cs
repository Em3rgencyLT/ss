using UnityEngine;
using System.Collections;

public class NetworkGUI : MonoBehaviour {

    public string address = "localhost";

    void Start () {
	    if(SystemInfo.graphicsDeviceID == 0)
        {
            this.enabled = false;
        }
	}

    void OnGUI()
    {
        address = GUI.TextField(new Rect(10, 10, 200, 20), address, 32);
        if (GUI.Button(new Rect(220, 10, 75, 20), "Connect"))
            gameObject.GetComponent<CustomNetworkManager>().ConnectToServer(address);
    }
}
