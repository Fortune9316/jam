using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Clock : MonoBehaviour {

    Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = PlayerPrefs.GetString("clock","08:00");
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
