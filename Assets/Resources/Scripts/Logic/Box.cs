using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

    public float speed;
    public direction boxDirection;

    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Treadmill") {
            speed = other.gameObject.GetComponent<ObjectsManager> ().boxSpeed;
            boxDirection = other.gameObject.GetComponent<ObjectsManager> ().dir;
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.name == "EndPhase") {
            Destroy (this.gameObject);
        }
        if (other.gameObject.name == "Furnace") {
            Destroy (this.gameObject);
        }
    }

    void Update () {
        Movement (boxDirection, speed);
    }

    void OnCollisionExit2D (Collision2D other) {
        if (other.gameObject.tag == "Treadmill") {
            speed = 0;
        }
    }

    public void Movement (direction dir, float speed) {
        if (dir == direction.left) {
            transform.Translate (Vector2.left * speed * Time.deltaTime);
        }
        else if (dir == direction.right) {
            transform.Translate (Vector2.right * speed * Time.deltaTime);
        }
        else if (dir == direction.up) {
            transform.Translate (Vector2.up * speed * Time.deltaTime);
        }
        else if (dir == direction.down) {
            transform.Translate (Vector2.down * speed * Time.deltaTime);
        }
    }

}
