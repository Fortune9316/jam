using UnityEngine;
using System.Collections;

public class OficinaController : MonoBehaviour {

    public GameObject light;
    ColorController[] controladores;
    RaycastHit2D hit;
    float cont;
    bool next;
	// Use this for initialization
	void Start () {
        cont = 0f;
        controladores = GetComponents<ColorController>();
        hit = new RaycastHit2D();
        next = false;
    }

    // Update is called once per frame
    void Update()
    {

        // control de la luz
        cont += Time.deltaTime;

        if (cont >= 1f)
        {
            if (light.gameObject.activeInHierarchy)
            {
                light.SetActive(false);
            }
            else
            {
                light.SetActive(true);
            }
            cont = 0f;
        }

        if (Input.GetMouseButtonDown(0))
        {

            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider.gameObject.tag == "object")
            {
                next = true;
            }
        }
            if(hit!=null)
        {
            if (next)
            {
                print("lanzando");
                for (int i = 0; i < controladores.Length; i++)
                {
                    controladores[i].ToColor("Almuerzo");
                }
            }

        }


    }
}
