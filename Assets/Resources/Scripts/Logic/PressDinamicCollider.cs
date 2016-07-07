using UnityEngine;
using System.Collections;

public class PressDinamicCollider : MonoBehaviour {

    public GameObject press;

    void Update () {
        MovePressCollider ();
    }

    void MovePressCollider () {
        transform.position = new Vector2 (press.transform.position.x, transform.position.y);
    }
}
