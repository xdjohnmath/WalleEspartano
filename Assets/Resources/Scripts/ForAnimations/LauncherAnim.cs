using UnityEngine;
using System.Collections;

public class LauncherAnim : MonoBehaviour {

	private Animator a;

	void Start () {
		a = GetComponent <Animator> ();
	}

	void OnMouseDown (){
		Click ();
	}

	public void Click () {
		a.SetBool ("a", true);
	}

	public void Back () {
		a.SetBool ("a", false);
	}
}
