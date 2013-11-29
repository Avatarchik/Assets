﻿using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {
	
	private Score score;

	// Use this for initialization
	void Start () {
		score = GameObject.FindWithTag("Manager").GetComponent<Score>();
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
		}
		
		//TOFIX : Ne détecte pas la Target quand on se pose dessus
		if(other.CompareTag("Target")){
			score.Add (-50);
			Debug.Log ("TARGEET");
			other.audio.Play();
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
