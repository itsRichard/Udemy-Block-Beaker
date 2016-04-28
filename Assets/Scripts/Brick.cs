﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public AudioClip crack;
	public Sprite[] hitSprites;
	//public so we can see it in the inspector and so level manager can have access to it 
	public static int breakableCount = 0;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;


	// Use this for initialization
	void Start () {

		// this refers to this particular instance 
		isBreakable = this.tag =="Breakable";
		//keep track of breakable bricks
		// as each brick comes into being, add a new brick
		if (isBreakable){
			breakableCount++;
		}
		print("The number of breakable bricks is: " + breakableCount);
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
		
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D col){ 
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits() {
		timesHit++;	
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			breakableCount--;
			Destroy(gameObject);
			levelManager.BrickDestroyed ();

		} else {
			LoadSprites();
		}
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	// TODO Remove this method once we can actually win!
	
	void SimulateWin(){
		levelManager.LoadNextLevel();

	}
}
