using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

    //Variáveis
    public Text wonBoxesT;
    public Text lostBoxesT;

    void Awake () {
        Screen.SetResolution (1024, 768, true);
    }

	void Update () {

        if (BoxManager.instance.lostBoxes > BoxManager.instance.wonBoxes+50) {
            print ("you lose, bitch");
        }
        //Mostrando texto
        wonBoxesT.text = "Você coletou: " + BoxManager.instance.wonBoxes.ToString () + "\nCaixas";
        lostBoxesT.text = "Você perdeu: " + BoxManager.instance.lostBoxes.ToString () + "\nCaixas";
	}
}
