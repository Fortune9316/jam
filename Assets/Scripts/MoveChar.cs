using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveChar : MonoBehaviour {

    Vector3 newPos;
    Vector3 pos;
    bool flag;
    float t;
    float dt;
    public float speed = 5f;
	// Use this for initialization
	void Start () {
        pos = transform.position;
        
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(newPos.x<transform.position.x)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }else
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            flag = true;
        }
        if (flag)
        {
            move();
        }
    }
    void move()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(newPos.x,transform.position.y,transform.position.z), step);

        if (t >= 1)
        {
            t = 0f;
            flag = false;
            pos = transform.position;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        SceneManager.LoadScene("Desayuno");
    }
}
