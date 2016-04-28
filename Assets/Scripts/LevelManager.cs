using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel (string name){
		
		Debug.Log ("Load Level Request: " + name);
		SceneManager.LoadScene (name);
		//Application.LoadLevel (name);
		Brick.breakableCount=0;

	}
	
	public void QuitRequest(){
		Debug.Log ("Quit Requested");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Brick.breakableCount=0;
		print ("Loading next level:" + SceneManager.GetActiveScene ());
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		// Application.LoadLevel (Application.loadedLevel+1);
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount<=0){
			LoadNextLevel ();
		}
	
	}

}
