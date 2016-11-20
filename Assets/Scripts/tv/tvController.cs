using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class tvController : MonoBehaviour {

    float cont;
    bool next;
    ColorController[] controladores;
    // Use this for initialization
    void Start () {
        cont = 0f;
        next = false;
        controladores = GetComponents<ColorController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit!=null)
            {
                if (hit.collider.gameObject.tag == "object")
                {
                    SceneManager.LoadScene("Dormitorio");
                }
                else
                {
                    next = true;
                }
            }
            
            if(next)
            {
                cont += Time.deltaTime;
                if(cont>=8f)
                {
                    for (int i = 0; i < controladores.Length; i++)
                    {
                        controladores[i].ToColor("Dormitorio");
                    }
                }
            }
        }
    }
}
