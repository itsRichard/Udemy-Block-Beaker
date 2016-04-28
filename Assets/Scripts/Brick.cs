using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public AudioClip crack;
	public Sprite[] hitSprites;
	//public so we can see it in the inspector and so level manager can have access to it 
	public static int breakableCount = 0;
	public GameObject smoke;
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
		AudioSource.PlayClipAtPoint (crack, transform.position,0.5f);
		if (isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits() {
		timesHit++;	
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			breakableCount--;
			PuffSmoke ();
			levelManager.BrickDestroyed ();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void PuffSmoke(){
		GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex] != null){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}else{
			Debug.LogError ("Sprite Missing");
		}
	}
	
	// TODO Remove this method once we can actually win!
	
	void SimulateWin(){
		levelManager.LoadNextLevel();

	}
}
