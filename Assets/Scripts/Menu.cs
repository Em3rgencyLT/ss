using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	
	private CustomNetworkManager networkManager;

	void Awake () 
	{
		networkManager = GameObject.Find("Custom Network Manager").GetComponent<CustomNetworkManager>();
		if(Debug.isDebugBuild)
		{
			GameObject.Find("ButtonHost").GetComponent<Button>().onClick.RemoveAllListeners();
			GameObject.Find("ButtonHost").GetComponent<Button>().onClick.AddListener(networkManager.StartupServer);
		}
		else
		{
			Destroy(GameObject.Find("ButtonHost"));
		}

		GameObject.Find("ButtonConnect").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("ButtonConnect").GetComponent<Button>().onClick.AddListener(networkManager.JoinServer);
	}
	
	
}
