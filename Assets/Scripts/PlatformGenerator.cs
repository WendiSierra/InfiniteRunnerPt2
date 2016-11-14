using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;

	private float platformWidth;
	public float distanceBetweenMin;
	public float distanceBetweenMax;


	private int platformSelector; 
	private float[] platformWidths;
	public objectPooler[] theObjectPools; 

	void Start () {
		
		platformWidths = new float[theObjectPools.Length];
														
		for (int i = 0; i < theObjectPools.Length; i++) 
		{
			platformWidths [i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
				
		}
	}
	

	void Update () {
		if (transform.position.x < generationPoint.position.x) 
		{
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

		
			platformSelector = Random.Range (0, theObjectPools.Length); 


			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2 ) + distanceBetween, transform.position.y, transform.position.z);

			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2 ), transform.position.y, transform.position.z);
		}
	}
}
