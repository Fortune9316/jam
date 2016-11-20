using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class splash : MonoBehaviour {

    float cont;
    public string name;
    public float time;
	// Use this for initialization
	void Start () {
        cont = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        cont += Time.deltaTime;
        if(cont>=time)
        {
            SceneManager.LoadScene(name);
        }
	}
    void pass(string name)
    {
        
    }
}
