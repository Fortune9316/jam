﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ViajeB : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(MsgController.instance.GetEndMsg())
        {
            SceneManager.LoadScene("Oficina_B");
        }
	
	}
}
