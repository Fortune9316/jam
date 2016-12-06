using UnityEngine;
using System.Collections;

public class ReunionController : MonoBehaviour {

    public GameObject jefeKey;
    ColorController[] controladores;
    RaycastHit2D hit;
    bool next;
    // Use this for initialization
    void Start () {
        controladores = GetComponents<ColorController>();
        hit = new RaycastHit2D();
        next = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {

            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider.gameObject.tag == "object")
            {
                next = true;
            }else
            {
                //texto
            }
        }
        if (hit != null)
        {
            if (next)
            {

                for (int i = 0; i < controladores.Length; i++)
                {
                    controladores[i].ToColor("Cena_B");
                }
            }

        }
    }
}
