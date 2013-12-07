using UnityEngine;
using System.Collections;

public class Moves : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float turnSpeed = 0.1f;
	
	public float smooth = 2.0F;
	
	public float gravity = 6;
	
	float rotX;
	float rotY;
	
	float angularTopDown;
	float angularLeftRight;
	
	private bool dontmove = false;
	
	void Start(){

		rigidbody.freezeRotation=true;
		Physics.gravity = new Vector3(0, -gravity, 0);
		
		StartCoroutine("Woohoo",1.0);

	}
	
	
    void Update ()
    {
		
		//Debug.Log ("coeff"+moveSpeed*Time.deltaTime, gameObject);
		
		if (!dontmove)
		{
	        if(Input.GetKey("z"))
	            transform.position += transform.up*moveSpeed;
	        
			if(Input.GetKey("s"))
	           transform.position -= transform.up*moveSpeed;
			
			if(Input.GetKey("d")){
				transform.position += transform.forward*moveSpeed;
			}	
			if(Input.GetKey("q"))
	            transform.position -= transform.forward*moveSpeed;
			
			if (Input.GetKey(KeyCode.Space))
	        {
	           // transform.Translate(0,0.2f,0);
				
				// GameObject.FindWithTag("bob").transform.Rotate(0, 0, 90);
				
	        }
		}
		
		
	
		rotX = Input.mousePosition.y - Screen.height/2;
		rotY = Input.mousePosition.x - Screen.width/2;
		
		//Debug.Log("angularTopDown = "+rotX/(Screen.height/140));
		
		angularTopDown = 90-rotX/(Screen.height/140);
		angularLeftRight =270+rotY/(Screen.width/10);
		
		
		
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
		audio.Play ();
	}
	
	public void dontMove()
	{
		dontmove = true;
	}
        
        
    }
