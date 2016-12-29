using UnityEngine;
using System.Collections;

public class Globo : MonoBehaviour {

	// Use this for initialization
	private float speed=0.2f;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * speed * Time.deltaTime);
	
	}
}
