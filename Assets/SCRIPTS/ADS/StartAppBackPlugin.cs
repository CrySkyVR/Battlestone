using UnityEngine;
using System.Collections;
using StartApp;

public class StartAppBackPlugin : MonoBehaviour{

	void Start () {
        if (Application.platform == RuntimePlatform.Android)
            StartAppWrapper.loadAd();
	
    }

	void Update () {
        if (Application.platform == RuntimePlatform.Android) {
            if (Input.GetKeyUp(KeyCode.Escape)) {
                if (StartAppWrapper.onBackPressed(gameObject.name) == false) {
                    Application.Quit();
                }
            }
        }
    }
}