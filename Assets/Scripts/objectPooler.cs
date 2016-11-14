using UnityEngine;
using System.Collections;
using System.Collections.Generic; // The "pool" commands are not default in Unity- adding this class will allow use to use lists

public class objectPooler : MonoBehaviour {

	public GameObject pooledObject; // This will allow us to define in unity the prefab for our list
	public int pooledAmount; //This will allow us to specify in Unity how many pooled objects we want

	List<GameObject> pooledObjects; //This creates a list, says it will be filled with game objects, and that they will be from pooled objects

	void Start () {
		pooledObjects = new List<GameObject> (); // This starts us off with an empty list at the start of the game

		//The code creates a "for" loop using the variable i. The loop will run as long as i is less than pooledAmount and will add 1 to i every time it runs
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate (pooledObject); //This creates a game object named obj, and creates a pooled object to be obj
			// (GameObject) in front of instantiate gives our newly create obj the class GameObject (this is called casting) 
			obj.SetActive(false); // sets our object as inactive
			pooledObjects.Add(obj); //adds our new obj to the list of polled objects. 
		}
	
	}
	
	public GameObject GetPooledObject (){ //this is a simple function that other scripts can call and use
			
		for (int i = 0; i < pooledObjects.Count; i++) { // like our earlier if statement, this one creates an internal variable, i, and checks it against the count of our list
			if (!pooledObjects [i].activeInHierarchy) {  //the square brackets tells unity to go to the pooled object in the same position as i and checks for if it's inactive in the hierarchy
				return pooledObjects[i]; //if it finds an inactive object, it "returns" it, meaning it will pass that object along to another function
				}
			}
		GameObject obj = (GameObject)Instantiate (pooledObject); //This code will create an object if our for loop doesn't find any available inactive objects 
		obj.SetActive(false); // this is the same as our code in the voide start function, but with an added line- return, allowing it to send an object back to the function that called it
		pooledObjects.Add(obj);  
		return obj;
		}
	}
