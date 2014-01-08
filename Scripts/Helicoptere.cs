using UnityEngine;
using System.Collections;

public class Helicoptere : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	IEnumerator playAfterDelay(float delay)
	{
		yield return new WaitForSeconds (delay);
		audio.Play ();
	}
}
