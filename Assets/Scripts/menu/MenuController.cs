using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject animateObject;
    private Vector3 actualScale;
    float t,dt;
    float target;
    bool loop;
    bool loop2;
    bool loop3;
	// Use this for initialization
	void Start () {
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
                SceneManager.LoadScene("Dormitorio");
                //loop2 = true;
                
            }
            if (t <= 0f)
            {
                SceneManager.LoadScene("Desayuno");
            }
        }
        //if(loop2 && !loop3)
        //{
        //    t = 0f;
        //    target = 0.0f;
        //    dt = 1;
        //    actualScale = animateObject.transform.localScale;
        //    loop3 = true;
        //}
        //if(loop3)
        //{
        //    animateObject.transform.localScale = Vector3.Lerp(actualScale, new Vector3(target, actualScale.y, actualScale.z), t);
        //}

        if (Input.GetMouseButtonDown(0))
        {
            loop = false;
            t = 0f;
            target = 1.8f;
            dt = 1;
            actualScale = animateObject.transform.localScale;
            //SceneManager.LoadScene("Desayuno");
        }

    }
}
