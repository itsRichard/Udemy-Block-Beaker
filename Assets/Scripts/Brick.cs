using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	private int timesHit;

	// Use this for initialization
	void Start () {
		timesHit = 0;
	}
		
	// Update is called once per frame
	void Update () {
	
	}
	
	void onCollisionEnter2D(Collision2D col){
		timesHit++;	
		print (timesHit);	
	}
}
