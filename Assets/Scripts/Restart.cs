using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    Pathmaker pathmakerScript;

    void Start ()
    {
        pathmakerScript = GameObject.Find("Pathmaker").GetComponent<Pathmaker>();
    }

	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main");
            pathmakerScript.tileCountReset = 0;
        }
	}
}
