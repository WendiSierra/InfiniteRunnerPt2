using UnityEngine;
using System.Collections;

public class PlatformDestroy : MonoBehaviour {

	public GameObject platformdestroy;

	void Start () {
		platformdestroy = GameObject.Find ("platformdestroy");
	}
	
	void Update () {
		if (transform.position.x < platformdestroy.transform.position.x) {
			//Destroy (gameObject);
			gameObject.SetActive(false); 
		}
	}
}
