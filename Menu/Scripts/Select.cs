using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	Color enterColor = Color.blue;
	int enterSize = 55;
	Color exitColor = Color.white;
	int exitSize = 50;
	
	void OnMouseEnter() {
		Debug.Log("mouseEnter in this GuiText :"+this.gameObject.name);
		
	    guiText.material.color = enterColor;
  		guiText.fontSize = enterSize;
	}

	void OnMouseExit() {
	    guiText.material.color = exitColor;
	    guiText.fontSize = exitSize;
	}
	
	void OnMouseUp() {
		Debug.Log("this name "+this.gameObject.name);
		
		if(this.gameObject.name == "Level_1")
        	Application.LoadLevel("Level_1");
		if(this.gameObject.name == "Level_2")
        	Application.LoadLevel("Level_2");
		if(this.gameObject.name == "Exit")
        	Application.Quit();
	}
	
}
