using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public Sprite[] hitSprictes;
	public static int breakableCount=0;
	public GameObject smoke;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	// Use this for initialization
	void Start () {
		
		isBreakable=(this.tag=="Breakable");
		// Keep track of breakable bricks
		if(isBreakable){
			breakableCount++;
		}
		timesHit=0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D col){
		AudioSource.PlayClipAtPoint(crack,transform.position,0.5f); 		
		if(isBreakable){
			HandleHits();
		}
	
	}
	void HandleHits(){
		timesHit++;
		int maxHits= hitSprictes.Length+1;
		if(timesHit>=maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke ();
			Destroy(gameObject);
			
		}else{
			LoadSprite();
		}
	}
	void LoadSprite(){
		int spriteIndex= timesHit -1;
		if(hitSprictes[spriteIndex] !=null){
		this.GetComponent<SpriteRenderer>().sprite=hitSprictes[spriteIndex];
		}else{
			Debug.LogError("Brick sprite missing");
		}
	}
	
	void PuffSmoke () {
				GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
				smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			}
	//TODO Remove this method once we can actually win!
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}
