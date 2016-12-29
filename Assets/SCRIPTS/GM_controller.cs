using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GM_controller : MonoBehaviour {

	// Use this for initialization

	private GameObject player;
	private Player player_scp;


	private GameObject enemigo;
	private Enemigo enemigo_scp;
	private int enemigo_nivel_dificultad;
	private float enemigo_cadencia_disparo;
	private bool enemigo_canShoot=false;

	private bool player_canShoot=true;
	private float player_cadencia_disparo;
	private float dec_player_cadencia_disparo;

	private Text energy_player_text;
	private Text energy_enemy_text;

	private int stoneDamage;
	private float dec_enemy_cadencia_disparo;


	private GameObject stone;

	private float DURATION_IN_SECONDS; // temporizador;

	private float insultoTimeleft;


	void Start () {

		insultoTimeleft = insultoTimeleft_random ();

		stoneDamage = 10;
		dec_enemy_cadencia_disparo = 0.5f;

		dec_player_cadencia_disparo = 0.2f; // La cadencia de disparo del player decrementará 0.2f

	//// PLAYER

		player = GameObject.Find ("player");
		player_scp = player.GetComponent<Player> ();


		energy_player_text = GameObject.Find ("energy_player_txt").GetComponent<Text> ();
	



	/// ENEMIGO

		enemigo = GameObject.Find ("enemigo");
		enemigo_scp = enemigo.GetComponent<Enemigo> ();
		enemigo_nivel_dificultad = enemigo_scp.nivel_dificultad;
		enemigo_cadencia_disparo = enemigo_scp.cadencia_disparo;

		energy_enemy_text = GameObject.Find ("energy_enemy_txt").GetComponent<Text> ();




		StartCoroutine(waitAndFadeEnemy(enemigo_cadencia_disparo)); //cadencia de disparo del enemigo INICIAMOS

	

	} // end Start
	
	// Update is called once per frame
	void Update () {

		player_cadencia_disparo = player_scp.cadencia_disparo; // actualizamos constantemente el dato de cadencia de disparo del player

		OnPintaEnemyScore (); // pintado constante de score de enemy
		OnPintaPlayerScore(); 

		if (Input.GetMouseButtonDown (0)) {
			if (player_canShoot && player_scp.Ialive) {
				Debug.Log ("Cadencia player: " + player_cadencia_disparo);
				player_scp.lanza_piedra (); 
				player_canShoot = false;
				StartCoroutine(waitAndFadePlayer(player_cadencia_disparo));
			}


		}

		if (enemigo_canShoot) {
			
			enemigo_scp.lanza_piedra ();
			enemigo_canShoot = false;
			StartCoroutine(waitAndFadeEnemy(enemigo_cadencia_disparo));
		}

		// función que controla el temporizador de insultos
	
		/*insultoTimeleft -= Time.deltaTime;
		Debug.Log ("tiempo: "+insultoTimeleft);
		if (insultoTimeleft < 0) {
			insultoTimeleft = insultoTimeleft_random ();

			player_scp.insulta ();

		}*/


	
	}// end update

	public void OnplayerEnergy_score(){

	

			//Debug.Log (player_scp.energia_var);

		Debug.Log ("god: " + player_scp.godMode);
		if (player_scp.Ialive && !player_scp.godMode){
			
			player_scp.energia_var -= stoneDamage; // Restamos energía al player si está vivo

			if (player_scp.energia_var ==0) {
				player_scp.Ialive = !player_scp.Ialive;
				//Debug.Log ("Game Over");
				restart ();
			}
		}// end if



	}// end OnplayerEnergy_score

	public void OnenemyEnergy_score(){


	

		enemigo_scp.energia_var -= stoneDamage;


		if (enemigo_scp.Ialive) {
			if (enemigo_scp.energia_var ==0) {

				//Debug.Log ("^^^^inicia subeNivel");
				subeNivel ();
			}
		}// end if



	}// end OnenemyEnergy_score

	public void OnPintaEnemyScore(){
		energy_enemy_text.text = enemigo_scp.nombres_enemigos[enemigo_scp.nivel_dificultad] +": "+ enemigo_scp.energia_var; // Actualiza el nombre del enemigo

	}

	public void OnPintaPlayerScore(){
		energy_player_text.text = "ELÍAS: " + player_scp.energia_var;

	}

	public void restart(){
		// NOTA: antes de cambiar de escena al menú, aparecerá un GAME OVER o YOU LOSE
		GameObject youlose=(GameObject) Instantiate(Resources.Load("you_lose"), new Vector2(0f,0f), Quaternion.identity);
		Destroy (youlose, 5f);

		StartCoroutine(returnToMenu(3f)); // Tiempo que dura la pausa hasta recomenzar pantalla

	}


	public void subeNivel(){

		GameObject levelup = (GameObject)Instantiate (Resources.Load ("levelup01"), new Vector2(0f,0f), Quaternion.identity);
		Destroy (levelup, 5f);
		//Debug.Log ("************* CAMBIA ENEMIGO");
		enemigo_scp.energia_var = enemigo_scp.ENERGIA; // reseteamos la energía del enemigo, al subir de nivel


		if(enemigo_scp.nivel_dificultad<enemigo_scp.total_niveles_dificultad){ // siempre que el nivel de dificulta no sea mayor que el total posible
		enemigo_scp.nivel_dificultad+=1;
		enemigo_scp.onCambiaEnemigo (); // actualiza animación de enemigo
		}


		if (enemigo_scp.cadencia_disparo>=0){ // siempre que no sea menor a 0, decrementa la cadencia de disparo del enemigo
			enemigo_scp.cadencia_disparo-=dec_enemy_cadencia_disparo;
			enemigo_cadencia_disparo = enemigo_scp.cadencia_disparo;

		}

		player_scp.cadencia_disparo -= dec_player_cadencia_disparo; // disminuimos en 0.5f la cadencia de disparo del jugador, para igualar

	


	} // end subeNivel();


	private float insultoTimeleft_random(){ // esta función devuelve un valor random para el temporizador de insultos
		float randomNum = Random.Range (6f, 10f);

		return(randomNum);

	}


	//********************* IENUMERATORS


	// Esta función sirve para generar un retraso en una acción. En este caso los efectos de la hostia.
	private IEnumerator waitAndFadeEnemy(float duration) { 

		yield return new WaitForSeconds(duration);

		enemigo_canShoot = true;
	


	}// End IEnumerator;
	private IEnumerator waitAndFadePlayer(float duration) { 

		yield return new WaitForSeconds(duration);

		player_canShoot = true;



	}// End IEnumerator;

	private IEnumerator returnToMenu(float duration) { // Retorno al menú

		yield return new WaitForSeconds(duration);

		Application.LoadLevel("menuscene");



	}// End IEnumerator;

}
