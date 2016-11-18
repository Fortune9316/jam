using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour {

	public string Texto;
	string text;
	int max,i;
	public float Delay;
	public Text Display;
	float currentTime;
	// Use this for initialization
	void Start () {
		text = "";
		max = Texto.Length;
		i = 0;
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime >= Delay) {
			if (i <= max) {
				text = Texto.Substring (0, i);
				i++;
				Display.text = text;
				//Debug.Log (text);

			}
			currentTime = 0;
		}
	}
}
