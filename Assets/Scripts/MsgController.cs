using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MsgController: MonoBehaviour {

	public static MsgController instancia;
	public bool PreReq, Req2;
	public bool BOWL, CEREAL, LECHE, Continuar;
	public string[] Textos;
	public float Delay;
	float CurrentTime;
	int Parrafo, i;
	public Text CajaTexto;
	string TextoDisplay, TextoActual;
	// Use this for initialization
	void Start () {
		Parrafo = 0;
		i = 0;
		TextoActual = "";
		Req2 = false;
	}

	void Awake(){
		instancia = this;
	}

	// Update is called once per frame
	void Update () {
	
		//***Ejemplo de llamada a función***//
		if (Input.GetMouseButtonDown(0))

		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			HuboClick (hit.collider);
		}
		DisplayText (TextoActual);

	}

	public int HuboClick(Collider2D Colly){
		if (!Continuar) {
			//Si aún no se cumplen los pre-requisitos tratar de cumplirlos
			if (!PreReq) {
				if (Colly != null) {
					if (Colly.gameObject.tag != "Untagged") {
						//Debug.Log (Colly.gameObject.name);
						PreReq = ValidaName (Colly.gameObject.name);
					}
				}
				//Si es Null no nos sirve para los pre-requisitos
				return 0;
			} else {
				//Si ya se cumplieron los pre-requisitos llamar a ShowNext()
				Req2=true;
				return ShowNext ();
			}
		}
		return 0;
	}

	bool ValidaName(string name)
	{
		switch (name) {
		case "BOWL":
			{
				if (!BOWL) {
					BOWL = true;
					//Muestra texto
					ShowNext("El super tazón");
				}
				break;
			}
		case "CEREAL":
			{
				if (!CEREAL) {
					CEREAL = true;
					//Muestra texto
					ShowNext("Los mega cereales");
				}
				break;
			}
		case "LECHE":
			{
				if (!LECHE) {
					LECHE = true;
					//Muestra texto
					ShowNext("y la mejor leche de vaca");
				}
				break;
			}
		}

		if (BOWL && CEREAL && LECHE) {
			return true;
		} else {
			return false;
		}
	}

	int ShowNext(string Cadena=null){

			if (Parrafo < Textos.Length) {
				//imprimir sgte secuencia de texto
				Continuar = true;
			if (Cadena == null) {
				TextoActual = Textos [Parrafo];
			} else {
				TextoActual = Cadena;}
			Debug.Log (Parrafo);
				return Parrafo;
			} else {
				//ya se terminó de mostrar
			Debug.Log("Fin de Array");
				return -1;
			}
			
	}

	public bool GetEndMsg(){
		if (Parrafo < Textos.Length) {
			return false;
		} else {
			return true;}
	}

	public void ActivatMsg(){
		PreReq = true;
		Req2 = true;
	}

	void DisplayText(string CurrText){
		if (Continuar) {
			CurrentTime += Time.deltaTime;
			if (CurrentTime >= Delay) {
				if (i <= CurrText.Length) {
					TextoDisplay = CurrText.Substring (0, i);
					i++;
					CajaTexto.text = TextoDisplay;
				} else {
					Continuar = false;
					i = 0;
					if (Req2) {
						Parrafo++;
					}
				}
				CurrentTime -= Delay;
			}
		}
	}

}