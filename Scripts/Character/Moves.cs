using UnityEngine;
using System.Collections;

public class Moves : MonoBehaviour
{
    public float moveSpeed = 11f;
    public float turnSpeed = 0.75f;
	
	public float smooth = 2.0f;
	
	public float gravity = 9.8f;
	
	public float magnitude = 0;
	public float maxSpeed = 125.0f;
	
	float rotX;
	float rotY;
	
	float angularTopDown;
	float angularLeftRight;
	
	private GameObject leftHand, rightHand; 
	private vrJoystick leftJoy;
	private vrJoystick rightJoy;
	
	private bool dontmove = false;
	
	public AudioClip woohoo;
	
	private Vector3 vRotate, vMove;
	
	void Start(){

		rigidbody.freezeRotation=true;
		Physics.gravity = new Vector3(0, -gravity, 0);
		
		
		//RAZER###########################
		leftHand = GameObject.FindWithTag("LeftHand");
		rightHand = GameObject.FindWithTag("RightHand");
		
		leftJoy = MiddleVR.VRDeviceMgr.GetJoystickByIndex(0);
		rightJoy = MiddleVR.VRDeviceMgr.GetJoystickByIndex(1);
				
		StartCoroutine("Woohoo",0.5);

	}
	
	
    void Update ()
    {
		
		//Debug.Log ("coeff"+moveSpeed*Time.deltaTime, gameObject);
		
		if (!dontmove)
		{
			//RAZER HYDRA #################################
			
			//Déplacement
			vMove = new Vector3(-rightJoy.GetAxisValue(0)*moveSpeed,rightJoy.GetAxisValue(2)*moveSpeed,-rightJoy.GetAxisValue(1)*moveSpeed);			

			//Rotation
			vRotate = new Vector3(leftJoy.GetAxisValue(0),leftJoy.GetAxisValue(2),-leftJoy.GetAxisValue(1));
			
			transform.position += vMove;
			transform.Rotate(vRotate, turnSpeed);
			
		
			if (leftJoy.IsButtonPressed (1) || rightJoy.IsButtonPressed (1))
				
				Application.LoadLevel("Menu");
			
			if (leftJoy.IsButtonPressed (2) || rightJoy.IsButtonPressed (2))
				
				Application.LoadLevel("Level_1");
			
			// ###############################################
			
			
			// Clavier Souris ##################################
			
	        if(Input.GetKey("up"))
	            transform.position += transform.up*moveSpeed;
	        
			if(Input.GetKey("down"))
	           transform.position -= transform.up*moveSpeed;
			
			if(Input.GetKey("right")){
				transform.position += transform.forward*moveSpeed;
			}	
			if(Input.GetKey("left"))
	            transform.position -= transform.forward*moveSpeed;
			
			if (Input.GetKey(KeyCode.M)) {
	         	 Application.LoadLevel("Menu");
	        }
			if (Input.GetKey(KeyCode.G)) {
	         	 Application.LoadLevel("Level_1");
	        }
			
			
			// ###############################################
		}
		
		//Hack pour que la vitesse ne dépasse pas maxSpeed
		
		if (rigidbody.velocity.magnitude > maxSpeed)
			rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
		
		
		magnitude = rigidbody.velocity.magnitude;
		
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
		
		 GameObject.Find("Vue").transform.localEulerAngles = new Vector3(angularTopDown,angularLeftRight,0);
		
		//Camera.main.transform.localEulerAngles = new Vector3(rotX%360,rotY%360,0);
		
		
		
		
		//Debug.Log("y deplacement = "+rotY);
		
		if(rotY >= 100){
			transform.Rotate(Vector3.right, turnSpeed);
		}
		if(rotY <= -100){
			transform.Rotate(Vector3.right, -turnSpeed);
		}
		
		
    }
	
	//Tout ça pour un foutu "Wouhouuu" x)
	IEnumerator Woohoo(float delay)
	{
		yield return new WaitForSeconds (delay);
		AudioSource.PlayClipAtPoint(woohoo, transform.position);
	}
	
	public void dontMove()
	{
		dontmove = true;
	}
        
        
}
