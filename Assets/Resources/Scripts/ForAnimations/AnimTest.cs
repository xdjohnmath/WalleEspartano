using UnityEngine;
using System.Collections;

public class AnimTest : MonoBehaviour {

	public 	ParticleSystem 	particle;


	void Start () {

		particle.Stop ();
	}

	void Update (){
		
	}

	public void Play (){
		particle.Play ();
	}

	public void Stop (){
		particle.Stop ();
	}

}
