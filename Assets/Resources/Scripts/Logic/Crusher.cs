using UnityEngine;
using System.Collections;

public class Crusher : MonoBehaviour {

    int dir;
    public float speed;

    void Start () {
        int side = Random.Range (0, 2);
        if (side == 0) {
            dir = -1;
        }
        else {
            dir = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate (Vector3.forward * dir * speed * Time.deltaTime);
	}
}
