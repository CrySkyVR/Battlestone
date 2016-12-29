using UnityEngine;
using System.Collections;

public class Stone02 : MonoBehaviour {

	// Use this for initialization
	public PowerController powerController_ins;

	public GameObject target_point;
	public Vector2 target_point_position; //seteado en instantiate desde Player y Enemigo

	public GM_controller gm_controller;


	private Rigidbody2D rigido2D;

	public GameObject ouch_ins;




	void Start () {



		gm_controller = GameObject.Find ("GM_controller").GetComponent<GM_controller> ();

		//target_point_position =GameObject.Find ("targetPoint_enemy").transform.position;

		//fuerzaSpeed = 500f;
		powerController_ins=GameObject.Find("powerController").GetComponent<PowerController>();

		int conversionPower = powerController_ins.timeLeftInt * 2;
		//int conversionPower = 500;
		//Debug.Log(conversionPower);

		rigido2D = GetComponent<Rigidbody2D> ();
		//rigido2D.AddForce (transform.right*conversionPower); // ojito, con 2D no vale el vector.up
		//rigido2D.AddForce (transform.TransformDirection(300f, 79f,0f)*conversionPower); // esto define un punto en el espacio, puede ser útil
		rigido2D.AddForce (target_point_position*conversionPower);

		//Debug.Log (rigido2D);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {



		//rigido2D.AddForce (Vector2.right * Time.deltaTime);
			

	
	}

	void OnCollisionEnter2D(Collision2D hit){
		//Debug.Log (this);

		AudioSource stone_hit = GetComponent<AudioSource> (); // play de sonido de piedra golpeando
		stone_hit.Play ();


		GameObject ouchClone = (GameObject)Instantiate (ouch_ins, transform.position, Quaternion.identity);
		Destroy (ouchClone, 2f);
		 

		//	GameObject clone=(GameObject) Instantiate(particle,transform.position, Quaternion.identity);

		if (hit.gameObject.name == "stone") {

			this.GetComponent<Collider2D>().enabled = false; // this (se supone) hace referencia a la instancia de stone (corroborar esto)



		}

		if (hit.gameObject.name == "enemigo") {

			Enemigo enemigo_scp = hit.gameObject.GetComponent<Enemigo> ();
			enemigo_scp.insulta ();

			gm_controller.OnenemyEnergy_score ();
			//Debug.Log ("golpea enemy");

		}
		if (hit.gameObject.name == "player") {

			Player player_scp = hit.gameObject.GetComponent<Player> ();
			player_scp.insulta ();

			gm_controller.OnplayerEnergy_score ();



		}





	} // end OnCollisionEnter


}
