using UnityEngine;
using System.Collections;

public class CheckDownMovement : MonoBehaviour {

    public GameObject parent;


	void OnTriggerStay2D (Collider2D other) {
        if (other.gameObject.tag == "Treadmill"){
            gameObject.GetComponent<BoxCollider2D> ().size = new Vector2 (1.5f, 1.5f);
            print ("hey bitch");
            if (other.gameObject.GetComponent<ObjectsManager>().dir == direction.down) {
                parent.transform.position = new Vector2 (parent.transform.position.x, other.gameObject.transform.position.y + .5f);

            }
        }
    }
}
