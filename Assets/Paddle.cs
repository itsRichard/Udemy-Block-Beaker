using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 paddlePos = new Vector3(0.5f,this.transform.position.y,0f);
		
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		paddlePos.x = Mathf.Clamp (mousePosInBlocks,0.5F,15.5F);
		
		this.transform.position = paddlePos;
		
	}
}
