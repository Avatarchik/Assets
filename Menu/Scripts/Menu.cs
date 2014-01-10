using UnityEngine;
using System.Collections;




public class Menu : MonoBehaviour {
	
	public Font fontFamily;
	public Color color;
	GUIStyle titleStyle;
	GUIStyle levelStyle;
	
	float duration = 6.0f;
	float moveDuration = 5.0f;
    float timer = 0.0f;
	float timer2 = 0.0f;
	bool opening = false;
	bool jump = false;
	
	GameObject doors;
	GameObject bob;
	
	public AudioClip buttonPressed; 
	public AudioClip doorOpening; 
	
	float x;
    float y;
	float z;
	
	// Use this for initialization
	void Start () {
	doors = GameObject.FindWithTag("Doors");
	bob = GameObject.FindWithTag("Bob");
		
	//RAZER	
//	leftJoy = MiddleVR.VRDeviceMgr.GetJoystickByIndex (0);
//	rightJoy = MiddleVR.VRDeviceMgr.GetJoystickByIndex (1);
		
	x = transform.position.x;
	y = transform.position.y;
	z = transform.position.z;
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		if (opening){
			timer += Time.deltaTime;
			 doors.transform.eulerAngles  = Vector3.Lerp(new Vector3(60, 0, 0),  new Vector3(0, 0, 0), timer/duration);
		}
				
		if(jump){
			timer2 += Time.deltaTime;
			bob.transform.position = Vector3.Lerp(new Vector3(x,y,z), new Vector3(x,y-4,z-20), timer2/moveDuration);
			bob.transform.eulerAngles  = Vector3.Lerp(new Vector3(0,270,0), new Vector3(0,270,90), timer2/moveDuration);
		}
		
		if (Input.GetKey(KeyCode.Backspace)  && !opening){
				StartCoroutine("playButtonPressed",0.0);
				StartCoroutine("playDoorOpening",1.0);
				StartCoroutine("moveOutdoor",moveDuration+1);
				StartCoroutine("launchLevel",duration+moveDuration -.5 );
	        }	
		//RAZER
//		if (leftJoy.IsButtonPressed (3) || rightJoy.IsButtonPressed (3))
//				
//				StartCoroutine("playButtonPressed",0.0);
//				StartCoroutine("playDoorOpening",1.0);
//				StartCoroutine("moveOutdoor",moveDuration+1);
//				StartCoroutine("launchLevel",duration+moveDuration -.5 );
//	        }	
		
	
	}
	
	IEnumerator playButtonPressed(float delay){
		yield return new WaitForSeconds (delay);
		AudioSource.PlayClipAtPoint(buttonPressed, transform.position);
	}
	
	IEnumerator playDoorOpening(float delay){
		yield return new WaitForSeconds (delay);
		AudioSource.PlayClipAtPoint(doorOpening, transform.position);
		opening = true;
	}
	
	IEnumerator moveOutdoor(float delay){
		yield return new WaitForSeconds (delay);
		jump=true;		
	}
	
	IEnumerator launchLevel(float delay){
		yield return new WaitForSeconds (delay);
		Application.LoadLevel("Level_1");		
	}
	
	
	
	/*
	void OnGUI() {
		
		titleStyle = new GUIStyle();
		
		titleStyle.fontSize = 100;
		titleStyle.font = fontFamily;
		titleStyle.normal.textColor = Color.red;
		
        GUI.Label(new Rect(Screen.width/2 -400, 100, 100, 20), "Projet Base Jump",titleStyle);
		
	
		Color c = new Color(0.5f,0.1f,0.1f);
		levelStyle = new GUIStyle();
		levelStyle.fontSize = 50;
		levelStyle.font = fontFamily;
		levelStyle.normal.textColor =  c;
		
		GUI.Label(new Rect(300, 200, 100, 20), "Niveau 1",levelStyle);
		GUI.Label(new Rect(300, 300, 100, 20), "Niveau 2",levelStyle);
		
	
    }
	*/
	
}
