using UnityEngine;
using System.Collections;
using System;

public class BoxManager : MonoBehaviour {

    //Singleton
    public static BoxManager instance = null;

    //Inicialização dos Objetos e variáveis
    GameObject launcher;
    public GameObject box;
    public int wonBoxes, lostBoxes;

    void Awake () {
        //Settando Singleton
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy (gameObject);
        }
        //Pega objeto Launcher
        launcher = GameObject.Find ("Launcher");

    }

	// Instacia a caixa ao digitar
	void LateUpdate () {
        if ((Input.anyKeyDown)) {
            InstantiateBox ();
        }
	}

    // Instacia a caixa ao clicar
    void OnMouseDown () {
        InstantiateBox ();
    }

    // Método de instaciar as caixas
    void InstantiateBox () {
        Instantiate (box, launcher.transform.position, Quaternion.identity);
    }

}
