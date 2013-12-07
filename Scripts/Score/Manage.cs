using UnityEngine;
using System.Collections;

public class Manage : MonoBehaviour {
	
	protected int score;
//		public AudioClip music;
	// Use this for initialization
	void Start () {
	
		score = 0;
//		audio.PlayOneShot (music);
	}
	
	// Update is called once per frame
	public void Add (int gain) {
		score+=gain;
	
	}
	
	public int Get () {
		return score;
	
	}
}


