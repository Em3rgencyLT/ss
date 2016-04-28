using UnityEngine;
using UnityEngine.Networking;
using System.Net;

public class C_NetworkManager : MonoBehaviour {

    public NetworkClient myClient;

    void Start () {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        string address = HostnameLookup("em3rgency.duckdns.org");
        if(address.Length > 0)
        {
            myClient.Connect("localhost", 1314);
        }
        else
        {
            Application.Quit();
        }

    }

    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
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
