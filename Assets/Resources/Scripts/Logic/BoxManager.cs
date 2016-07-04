using UnityEngine;
using System.Collections;
using System;

public class BoxManager : MonoBehaviour {

    GameObject launcher;
    public GameObject box;

	void Awake () {
        launcher = GameObject.Find ("Launcher");
	}

	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown (KeyCode.Space)) {
            SetBoxPosition ();
        }
	}

    void SetBoxPosition () {
        Instantiate (box, launcher.transform.position, Quaternion.identity);
    }

}
