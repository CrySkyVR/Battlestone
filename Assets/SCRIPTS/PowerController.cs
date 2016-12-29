using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerController : MonoBehaviour {

	// Use this for initialization
	public int power=0;
	private float powerAument=70f;


	private Text powerText;

	private float timeLeft=0;
	public int timeLeftInt;
	private bool direccionNumber=true;

	private GameObject barPower;
	private float barPower_width;

	void Start () {
		
		//powerText = GameObject.Find ("power").GetComponent<Text> ();
		barPower = GameObject.Find ("barPower");
		barPower_width = barPower.transform.localScale.x;

	
	}
	
	// Update is called once per frame
	void Update () {


		// controlador animación barra power
		if (timeLeftInt < 100 && direccionNumber) {
			timeLeft += powerAument * Time.deltaTime;

		} else{

			direccionNumber = false;

		}


		if (timeLeftInt > 0 && !direccionNumber) {

			timeLeft -= powerAument * Time.deltaTime;

		} else {

			direccionNumber = true;

		}

		timeLeftInt = (int)timeLeft; //float to int


		float con=(barPower_width/100)*timeLeftInt;

		barPower.transform.localScale = new Vector3(con, barPower.transform.localScale.y, 0); //escala de barra (valor variable, valor que ya tenía, z);



	}
}
