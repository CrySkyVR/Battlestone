using UnityEngine;
using System.Collections;

public class Ouch : MonoBehaviour {

	// Use this for initialization
	public float speed=0.5f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		transform.Translate (Vector2.up * speed* Time.deltaTime);
	
	}
}
