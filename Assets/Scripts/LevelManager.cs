using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel (string name){
		Debug.Log ("Load Level Request: " + name);
		Application.LoadLevel (name);
	}
	
	public void QuitRequest(){
		Debug.Log ("Quit Requested");
		Application.Quit();
	}

}
