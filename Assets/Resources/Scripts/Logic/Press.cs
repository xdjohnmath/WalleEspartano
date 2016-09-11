using UnityEngine;
using System.Collections;

public class Press : MonoBehaviour {

    Animator anim;
    public float time;
    float tempTime;

    void Start () {
        tempTime = time;
        anim = gameObject.GetComponent<Animator> (); 
    }

    void Update () {
        SettingPress ();
    }

    void SettingPress () {
        tempTime -= Time.deltaTime;
        if (tempTime <= 0) {
            anim.SetBool ("CanGo", true);
        }
    }

    public void AnimationHasEnded () {
        anim.SetBool ("CanGo", false);
        tempTime = time;
    }
}
