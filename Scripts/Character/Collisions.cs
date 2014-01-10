using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {
	
	private Manage manage;
	private Moves move;
	private bool dead = false;

	// Use this for initialization
	void Start () {
		manage = GameObject.FindWithTag("Manager").GetComponent<Manage>();
		move = GetComponent<Moves>();
	}
	
	void OnTriggerEnter(Collider other) {
		
        if(other.CompareTag("Glass")){
			Debug.Log ("Glass");
			manage.AddScore(10);
			manage.SoundPlay ("glass");
			
			
		}
		
//		else if(other.CompareTag("Target")){
//			dead = true; //well not really but...
//			other.collider.enabled = false;
//			Debug.Log ("TARGET");
//			{
//				manage.AddScore (50);
//				manage.SoundPlay ("target");
//			}
			
//		}
	}
	
	void OnCollisionEnter(Collision col) {
		GameObject other = col.gameObject;

		
		if(other.CompareTag("Ground")){
			Debug.Log ("GRROUUUUUND - Position : " + transform.position);
			if (!dead) {
				if(transform.position.x > 693 && transform.position.x < 923 && transform.position.z > 1564 && transform.position.z < 1786){
					Debug.Log ("Clap clap");
					manage.SoundPlay ("target");
				}
				else{
					Debug.Log ("Aargh");
					manage.SoundPlay ("ground");
				}
				 
			move.dontMove();
			dead = true;
				
			}
			
		}

	}
	
	void OnCollisionExit(Collision col) {
		GameObject other = col.gameObject;
		
		if(other.CompareTag("Building")){
				manage.AddScore (-20);
				manage.SoundPlay ("building");
		}
	}
	//Gagner des points en frolant les batiments
	
	//if(Vector3.Distance(transform.position, player.position) < distance){
	//	playerCloseEnough = true;
	//	}
	//	else{
	//	playerCloseEnough = false;
	//	}
}
