using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization

	public int ENERGIA;
	public int energia_var;

	private Animator player_animator;

	private Vector2 spawnStone_player_pos;

	private GameObject stone;
	private Stone02 stone_scp;
	private Vector2 stone_targetPoint;

	private Vector2 globoSpawner;

	public float cadencia_disparo;

	public bool Ialive;

	public bool godMode;


	void Awake(){ // Esto asegura que los putos valores del inspector sean overrideados

		ENERGIA = 100;
		energia_var = ENERGIA;

		cadencia_disparo = 1f; // decrementará en 0.2f tras cada levelup

		Ialive = true;
		godMode = false;

	
	}

	void Start () {

		globoSpawner = GameObject.Find ("globoSpawner_player").transform.position;


		player_animator = GetComponent<Animator> ();


		spawnStone_player_pos = GameObject.Find ("spawnStone_player").transform.position; // Posición desde la que se arrojará la piedra
	
	}
	
	// Update is called once per frame


	public void lanza_piedra(){

		player_animator.Play ("ch_launch");

		stone = (GameObject) Instantiate (Resources.Load ("stone"),spawnStone_player_pos, Quaternion.identity);
		// Al instanciar, seteamos el target_point_position de cada stone
		stone_scp = stone.GetComponent<Stone02> ();
		stone_scp.target_point_position = GameObject.Find ("targetPoint_enemy").transform.position;
		Destroy (stone, 4f);
		//Debug.Log ("act");


	} // end lanzaPiedra();


	public void insulta(){

		GameObject my_insulto = (GameObject)Instantiate (Resources.Load ("globos01"), globoSpawner, Quaternion.identity);
		Destroy (my_insulto, 2f);

	}


}
