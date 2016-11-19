using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ViajeA : MonoBehaviour
{
    ColorController[] controladores;
    public GameObject abuela;
    public GameObject abuelaB;
    public GameObject targetAbuela;
    public GameObject secondTargetAbuela;
    public GameObject car;
    public GameObject carB;
    private Vector3 posAbuela;
    RaycastHit2D hit;
    float cont;
    float maxDistanceDelta;
    bool flag, firstTime;
    bool flag2;
	public MsgController Cont0, Cont1, Cont2;

    // Use this for initialization
    void Start()
    {
        controladores = GetComponents<ColorController>();
        flag = true;
        flag2 = false;
        cont = 0f;
        posAbuela = abuela.transform.position;
        hit = new RaycastHit2D();
		firstTime = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(flag)
        {
            float step = 0.5f * Time.deltaTime;
            abuela.transform.position = Vector3.MoveTowards(abuela.transform.position, targetAbuela.transform.position, step);
        }

		if (Cont0.GetEndMsg()&&(flag2!=true)) {
			Debug.Log ("Cambiar al texto de abuela");
			Cont0.enabled = false;
			Cont1.enabled = true;
		}

        if(Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        }
        
        abuelaB.transform.position = abuela.transform.position;
        if (Vector3.Distance(abuela.transform.position, targetAbuela.transform.position) <= 0.2f)
        {
            print("entre");
            cont += Time.deltaTime;
            flag = false;
        }
            if(cont>=10f && flag2!=true)
            {
                float step1 = 0.5f * Time.deltaTime;
                abuela.transform.position = Vector3.MoveTowards(abuela.transform.position, secondTargetAbuela.transform.position, step1);
            abuelaB.transform.position = Vector3.MoveTowards(abuelaB.transform.position, secondTargetAbuela.transform.position, step1);
            }
		if (Vector3.Distance (abuela.transform.position, secondTargetAbuela.transform.position) <= 0.2f) {
			SceneManager.LoadScene ("OFICINA_B");
		}
        
		if((hit.collider.gameObject.tag == "minusTime" && !flag2)&&(Cont1.enabled==false))
        {
			flag2 = true;
        }

		if ((flag2) && (Cont0.GetEndMsg () == true)) {
			if (firstTime) {
				car.GetComponent<CarController> ().evasion ();
				carB.GetComponent<CarController> ().evasion ();
				Cont0.enabled = false;
				Cont2.enabled = true;
				firstTime = false;
			} else {
				car.GetComponent<CarController> ().GoOn ();
				carB.GetComponent<CarController> ().GoOn ();
				for (int i = 0; i < controladores.Length; i++) {
					controladores [i].ToColor ("Oficina_A");
				}
			}
		}
        
    }
}
