using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	// Use this for initialization
	public PowerController powerController_ins;

	private GameObject targetPoint_enemy;
	private Vector2 targetPoint_enemy_position;

	private Rigidbody2D rigido2D;

	void Start () {

		targetPoint_enemy = GameObject.Find ("targetPoint_enemy");
		targetPoint_enemy_position = targetPoint_enemy.transform.position;

		//fuerzaSpeed = 500f;
		powerController_ins=GameObject.Find("powerController").GetComponent<PowerController>();

		int conversionPower = powerController_ins.timeLeftInt * 2;
		//int conversionPower = 500;
		//Debug.Log(conversionPower);

		rigido2D = GetComponent<Rigidbody2D> ();
		//rigido2D.AddForce (transform.right*conversionPower); // ojito, con 2D no vale el vector.up
		//rigido2D.AddForce (transform.TransformDirection(300f, 79f,0f)*conversionPower); // esto define un punto en el espacio, puede ser útil
		rigido2D.AddForce (targetPoint_enemy_position*conversionPower);

		//Debug.Log (rigido2D);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {



		//rigido2D.AddForce (Vector2.right * Time.deltaTime);
			

	
	}

	void OnCollisionEnter2D(Collision2D hit){

		if (hit.gameObject.name == "enemigo") {

			Debug.Log ("golpea");

		}




	} // end OnCollisionEnter


}
