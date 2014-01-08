using UnityEngine;
using System.Collections;

public class Vue : MonoBehaviour {

	GameObject cam;
	
	// Use this for initialization
	void Start () {
		cam = GameObject.Find("Vue");
	}
	
	
	float rotX;
	float rotY;
	
	float angularTopDown;
	float angularLeftRight;
	
	// Update is called once per frame
	void Update () {
		
		rotX = Input.mousePosition.y - Screen.height/2;
		rotY = Input.mousePosition.x - Screen.width/2;
		
		//Debug.Log("angularTopDown = "+rotX/(Screen.height/140));
		
		angularTopDown = 90-rotX/(Screen.height/140);
		angularLeftRight =270+rotY/(Screen.width/50);
		
		
		
		if((angularTopDown)>150)
			angularTopDown = 150;
		if((angularTopDown)< 10)
			angularTopDown = 10;
		
		//Debug.Log("angularTopDown = "+angularTopDown+" angularLeftRight = "+angularLeftRight);
		
		 cam.transform.localEulerAngles = new Vector3(angularTopDown,angularLeftRight,0);
	
	}
}
