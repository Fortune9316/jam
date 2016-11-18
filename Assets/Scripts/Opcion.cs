using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Opcion : MonoBehaviour {

    public GameObject btn;
	public string Scena;
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
				if(hit.collider.gameObject==gameObject)
                {
					Debug.Log (hit.collider.gameObject.name);
					SceneManager.LoadScene (Scena);
                }
            }
        }
	}
}
