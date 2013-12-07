using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {
	
	private Manage score;
	private Moves move;

	// Use this for initialization
	void Start () {
		score = GameObject.FindWithTag("Manager").GetComponent<Manage>();
		move = GetComponent<Moves>();
	}
	
	void OnTriggerEnter(Collider other) {
		
        if(other.CompareTag("Glass")){
			Debug.Log ("Glass");
			score.Add(10);
			other.audio.Play();
			Destroy(other);
			//TODO : Animation de destruction ?
			//L'objet n'est pas détruit ?
		}
		
		if(other.CompareTag("Target")){
			Debug.Log ("TARGET");
			score.Add (-50);
			other.audio.Play();
			
		}
	}
	
	void OnCollisionEnter(Collision col) {
		GameObject other = col.gameObject;
		
		if(other.CompareTag("Building")){
			score.Add (-20);
			other.audio.Play ();
			//TODO : Louder. On l'entend à peine le son.
		}
		
		if(other.CompareTag("Ground")){
			score.Add (50);
			Debug.Log ("GRROUUUUUND");
			other.audio.Play();
			move.dontMove();
			
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
