using UnityEngine;
using System.Collections;

public class PointObject : MonoBehaviour {

    public GameObject player;
    public Vector3 newPos;
    public GameObject colorElement;
    private Vector3 pos;
    bool flag;
    private float t;
    SpriteRenderer sp;
	// Use this for initialization
	void Start () {
        flag = false;
        t = 0f;
        pos = player.transform.position;
        sp = colorElement.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                
                Debug.Log(hit.collider.gameObject.tag);
                if(hit.collider.gameObject.tag == "Player")
                {
                    sp.color = new Color(1f, 1f, 1f);
                }
            }
            newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            flag = true;
        }

        if(flag)
        {
            move();
        }
	}
    void move()
    {
        print("ccc");
        player.transform.position = Vector3.Lerp(pos, newPos , t);
        player.transform.position = new Vector3(player.transform.position.x, pos.y, pos.z); 
        t += Time.deltaTime;
        
        if(t>=1)
        {
            t = 0f;
            flag = false;
            pos = player.transform.position;
        }
    }
}
