using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject animateObject;
    public GameObject arrow;
    public GameObject headB;
    private Vector3 actualScale;
    float t,dt;
    float target;
    bool loop;
    bool loop2;
    bool loop3;
    bool beatKey;
    float counter;
    float tArrow;
	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteAll();
        tArrow = 0f;
        counter = 0f;
        beatKey = true;
        t = 0;
        dt = 1f;
        target = 1.0f;
        actualScale = animateObject.transform.localScale;
        loop = true;
        loop2 = false;
        loop3 = false;
    }
	
	// Update is called once per frame
	void Update () {
        
        if(loop)
        {
            animateObject.transform.localScale = Vector3.Lerp(actualScale, new Vector3(target, actualScale.y, actualScale.z), t);

            t += Time.deltaTime * 0.5f * dt;
            if (t >= 1f)
            {
                dt = -1;
            }
            if (t <= 0f)
            {
                dt = 1;
            }
        }else if(!loop2)
        {
            animateObject.transform.localScale = Vector3.Lerp(actualScale, new Vector3(target, actualScale.y, actualScale.z), t);

            t += Time.deltaTime * 0.5f * dt;
            if(t>=1f)
            {
                loop2 = true;
                arrow.SetActive(false);
                headB.SetActive(true);
                t = 1f;
                dt = -1;
                actualScale = animateObject.transform.localScale;
            }
        }

        if(loop2)
        {
            print("Hola");
            animateObject.transform.localScale = Vector3.Lerp(new Vector3(0f, actualScale.y, actualScale.z), actualScale, t);
            t += Time.deltaTime * 0.5f * dt;

            if(t<=0f)
            {
                SceneManager.LoadScene("Dormitorio");
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            loop = false;
            t = 0f;
            target = 1.8f;
            dt = 1;
            actualScale = animateObject.transform.localScale;
            
        }

    }
    
}
