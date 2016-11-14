using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    public TextAsset text;
    string allText;
    List<string> eachline;
    public string[] objectsToBeMade;
    string a = "rola";

    void Start () {

        eachline = new List<string> ();

        allText = text.text;

        eachline.AddRange (allText.Split ("\n"[0]));

        gameObject.GetComponent<Text>().text = string.Format( eachline[Random.Range(0, eachline.Count-1)], objectsToBeMade[Random.Range(0, objectsToBeMade.Length-1)]);
      
	}
	

}
