using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour {

	// Use this for initialization
	public int ENERGIA;
	public int energia_var;

	public float cadencia_disparo;

	public int nivel_dificultad;
	public int total_niveles_dificultad;

	private Animator enemigo_animator;

	private Vector2 spawnStone_enemy_pos;

	private GameObject stone;
	private Stone02 stone_scp;
	private Vector2 stone_targetPoint;

	private Vector2 globoSpawner;

	public bool Ialive = true;

	public string[] animaciones_idle;
	public string[] animaciones_launch;
	public string[] nombres_enemigos;




	void Awake(){ // Esto asegura que los putos valores del inspector sean overrideados

		ENERGIA = 100;
		energia_var = ENERGIA;

		nivel_dificultad = 0;

		cadencia_disparo = 3f;

		animaciones_idle = new string[]{"en_idle","en_vieja_idle","en_cura_idle","en_braulio_idle","en_anciana_idle","en_flaco_idle","en_berserker_idle" }; // array de animaciones de enemigos. Ha de estar aquí, o de otro modo desde el start de GM_controller, da 0 como valor
		animaciones_launch= new string[]{"en_bartolome_launch","en_vieja01_launch","en_cura_launch","en_braulio_launch","en_anciana_launch","en_flaco_launch","en_berserker_launch"};
		nombres_enemigos = new string[]{"BARTOLOMÉ","ENGRACIA", "DON COSME","BRAULIO", "DOÑA EUSTAQUIA", "JUAN PATAGALLO", "BERSERKER" };

		total_niveles_dificultad = animaciones_idle.Length-1; // el total de niveles es equivalente a personajes en array

	}


	void Start () {

	

		globoSpawner = GameObject.Find ("globoSpawner_enemy").transform.position;

		enemigo_animator = GetComponent<Animator> ();

		spawnStone_enemy_pos = GameObject.Find ("spawnStone_enemy").transform.position;

		onCambiaEnemigo (); // Me veo obligado a inicializar desde aquí, ya que desde GM_controller da null al animator
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onCambiaEnemigo(){

		enemigo_animator.Play (animaciones_idle[nivel_dificultad]); // cambia la animación del enemigo según la dificultad
	

	}

	public void lanza_piedra(){

		enemigo_animator.Play (animaciones_launch[nivel_dificultad]); // aquí irá en_launch

		stone = (GameObject) Instantiate (Resources.Load ("stone"),spawnStone_enemy_pos, Quaternion.identity);
		// Al instanciar, seteamos el target_point_position de cada stone
		stone_scp = stone.GetComponent<Stone02> ();
		stone_scp.target_point_position = GameObject.Find ("targetPoint_player").transform.position;

		Destroy (stone, 2f);


	}// end lanzaPiedra();

	public void insulta(){

		GameObject my_insulto = (GameObject)Instantiate (Resources.Load ("globos01"), globoSpawner, Quaternion.identity);
		Destroy (my_insulto, 2f);

	}






}
