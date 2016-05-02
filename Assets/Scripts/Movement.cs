using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour {

	public float currentX;
	public float currentY;
	public float currentZ;

        void Awake ()
        {
		currentX = transform.getX();
		currentY = transform.getY();
		currentZ = transform.getZ();	
	}

	void Update()
	{

	} 
}

