using UnityEngine;
using System.Collections;

public class GeneralControls : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Cursor.visible = !Cursor.visible;
        }
	}
}
