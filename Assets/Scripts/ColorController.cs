using UnityEngine;
using System.Collections;

public class ColorController : MonoBehaviour {

    public GameObject color;
    public GameObject black;

    private SpriteRenderer spC;
    private SpriteRenderer spB;
	// Use this for initialization
	void Start () {
        spB = black.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.Space))
        {
            Color color = spB.color;
            color -= new Color(0f, 0f, 0f, 0.01f);
            spB.color = color;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            Color color = spB.color;
            color += new Color(0f, 0f, 0f, 0.01f);
            spB.color = color;
        }
    }
}
