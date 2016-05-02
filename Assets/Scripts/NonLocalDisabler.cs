using UnityEngine;
using UnityEngine.Networking;

public class NonLocalDisabler : NetworkBehaviour {

    public Behaviour[] components;

	void Start () {
        if (!isLocalPlayer)
        {
            for(int i = 0; i < components.Length; i++)
            {
                components[i].enabled = false;
            }
        }
	}
}
