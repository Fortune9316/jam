using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Oficina2Controller : MonoBehaviour {

	public MsgController Cont0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Cont0.GetEndMsg ()) {
			SceneManager.LoadScene ("Almuerzo");
		}

	}
}
