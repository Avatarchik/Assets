using UnityEngine;
using System.Collections;

public class Manage : MonoBehaviour {
	
	private int score;
	public AudioClip buildingAie;
	public AudioClip groundAie;
	public AudioClip glassAie1;
	public AudioClip glassAie2;
	public AudioClip targetClap;
	
	private int glassChoice = 1;


	void Start () {
	
		score = 0;
		//audio.PlayOneShot (music);
	}
	
	// Update is called once per frame
	public void AddScore (int gain) {
		score+=gain;
	
	}
	
	public int GetScore () {
		return score;
	
	}
	
	public void SoundPlay(string sound) {
	
		if (sound.Equals("building"))
			audio.PlayOneShot (buildingAie);
		else if (sound.Equals ("ground"))
			audio.PlayOneShot (groundAie);
		else if (sound.Equals ("glass")) { //On alterne le bruit de bris de glace
			if (glassChoice == 1) {
				audio.PlayOneShot (glassAie1);
				glassChoice++;
			}
			else {
				audio.PlayOneShot (glassAie2);
				glassChoice--;
			}
		}
		else if (sound.Equals ("target"))
			audio.PlayOneShot (targetClap);
		
	}
}


