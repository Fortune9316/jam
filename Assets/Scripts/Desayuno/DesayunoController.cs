using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DesayunoController : MonoBehaviour {

    ColorController [] controladores;
    int boul;
    int leche;
    int cereal;
    float cont;
	// Use this for initialization
	void Start () {
        cont = 0f;
        boul = PlayerPrefs.GetInt("DB", 0);
        leche = PlayerPrefs.GetInt("DL", 0);
        cereal = PlayerPrefs.GetInt("DC", 0);
        controladores = GetComponents<ColorController>();
    }
	
	// Update is called once per frame
	void Update () {
        cont += Time.deltaTime;
        boul = PlayerPrefs.GetInt("DB", 0);
        leche = PlayerPrefs.GetInt("DL", 0);
        cereal = PlayerPrefs.GetInt("DC", 0);
        if (boul == 0 && leche ==0 && cereal==0 && cont>=15f)
        {
            for(int i=0;i<controladores.Length;i++)
            {
                controladores[i].ToColor("Viaje_A");
            }
        }
		if (boul != 0 && leche != 0 && cereal != 0) {
			if (MsgController.instancia.GetEndMsg()) {
				SceneManager.LoadScene ("Viaje_B");}
			}
        }
}
