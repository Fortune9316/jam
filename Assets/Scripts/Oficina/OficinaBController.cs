using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OficinaBController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(MsgController.instance.GetEndMsg())
        {
            SceneManager.LoadScene("Almuerzo");
        }
	}
}
