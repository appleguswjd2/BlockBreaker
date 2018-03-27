using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoplay=false;
	private Ball ball;
	public float minX,maxX;
	void Start () {
		ball=GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoplay){
			MoveWithMouse();
		}else {
			AutoPlay();
		}
			
	}
	
	void AutoPlay(){
		Vector3 paddlePos = new Vector3(0.5f,this.transform.position.y,0f);//paddle position setting
		Vector3 ballPos=ball.transform.position;		
		paddlePos.x=Mathf.Clamp(ballPos.x,minX,maxX);//paddle range according to the mouse position
		
		this.transform.position = paddlePos;
	}	
	
	
	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3(0.5f,this.transform.position.y,0f);//paddle position setting
		
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16; //mouse range
		
		paddlePos.x=Mathf.Clamp(mousePosInBlocks,minX,maxX);//paddle range according to the mouse position
		
		this.transform.position = paddlePos;
		
	}
	
	
}

