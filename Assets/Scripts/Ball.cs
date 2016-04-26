using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public Paddle paddle;
	public bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		// stick ball to the paddle by finding the difference between ball and paddle and setting
		paddleToBallVector=this.transform.position - paddle.transform.position;
		print (paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted) {
			// lock ball relative to the paddle for as long as the game has not started
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}
		
		if(Input.GetMouseButtonDown (0)){
			hasStarted=true;
			print ("Mouse button clicked; ball launched");
			this.rigidbody2D.velocity = new Vector2 (2f,10f);
		}
	}
}
