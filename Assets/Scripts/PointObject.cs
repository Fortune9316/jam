using UnityEngine;
using System.Collections;

public class PointObject : MonoBehaviour {

    public GameObject targetB;
    public GameObject targetL;
    public GameObject targetC;
    public GameObject boulB;
    public GameObject lecheB;
    public GameObject cerealB;
    private Vector3 pos;
    bool flag;
    private float t;
    SpriteRenderer sp;
	// Use this for initialization
	void Start () {
        flag = false;
        t = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if(hit.collider.gameObject.tag == "boul")
                {
                    Blink(targetB.transform.position, hit.collider.gameObject,boulB);
                    PlayerPrefs.SetInt("DB", 11);
                }
                if (hit.collider.gameObject.tag == "leche")
                {
                    Blink(targetL.transform.position, hit.collider.gameObject,lecheB);
                    PlayerPrefs.SetInt("DL", 12);
                }
                if (hit.collider.gameObject.tag == "cereal")
                {
                    Blink(targetC.transform.position, hit.collider.gameObject,cerealB);
                    PlayerPrefs.SetInt("DC", 13);
                }
            }
    
        }

        
	}
    void Blink(Vector3 target, GameObject obj , GameObject objB)
    {
        obj.transform.position = target;
        objB.transform.position = target;
    }
    
    
}
