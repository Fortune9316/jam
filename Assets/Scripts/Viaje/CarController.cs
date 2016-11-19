using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

    float runningTime = 0f;
    public float speed;
    public GameObject llanta1,llanta2;
    float cont;
    bool flag;
	// Use this for initialization
	void Start () {
        flag = true;
        cont = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        OnCar();
        if (flag)
        {
            GoOn();
            rotateLL(llanta1, llanta2);
        }
        
	}
    void OnCar()
    {
        Vector3 newPos = transform.position;
        float deltaHeight = (Mathf.Sin(runningTime + Time.deltaTime) - Mathf.Sin(runningTime));
        newPos.y += deltaHeight * 0.08f;
        runningTime += Time.deltaTime * 15f;
        transform.position = newPos;
    }
    public void GoOn()
    {
        transform.position += new Vector3(5f * Time.deltaTime, 0f, 0f);
        llanta1.transform.position += new Vector3(5f * Time.deltaTime, 0f, 0f);
        llanta2.transform.position += new Vector3(5f * Time.deltaTime, 0f, 0f);
    }
    void rotateLL(GameObject a, GameObject b)
    {
        a.transform.Rotate(new Vector3(0f, 0f, 5f * Time.deltaTime + speed));
        b.transform.Rotate(new Vector3(0f, 0f, 5f * Time.deltaTime + speed));
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        flag = false;
    }

    public void evasion()
    {
        transform.position += new Vector3(0f, -2f, 0f);
        llanta1.transform.position += new Vector3(0f, -2f, 0f);
        llanta2.transform.position += new Vector3(0f, -2f, 0f);
    }

}
