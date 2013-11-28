using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	protected int score;
	// Use this for initialization
	void Start () {
	
		score = 0;
	}
	
	// Update is called once per frame
	public void Add (int gain) {
		score+=gain;
	
	}
	
	public int Get () {
		return score;
	
	}
}


