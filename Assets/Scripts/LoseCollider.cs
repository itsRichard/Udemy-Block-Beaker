using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager LevelManager;
	
	void OnCollisionEnter2D (Collision2D collision) {
		print("Collision");
	}
	
	//When the Lose Collider is triggered...
	void OnTriggerEnter2D (Collider2D trigger){
		// Find the thing to manage levels
		LevelManager = GameObject.FindObjectOfType<LevelManager>();
		
		// .. then, switch the level.  
		LevelManager.LoadLevel ("Loose"); 
		}

}
