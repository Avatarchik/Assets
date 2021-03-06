﻿using UnityEngine;
using System.Collections;
 
public class ProgressBar : MonoBehaviour {
    public float barDisplay; //current progress
    public Vector2 pos = new Vector2(100,100);
    public Vector2 size = new Vector2(600,20);
    public Texture2D emptyTex;
    public Texture2D fullTex;
	private GameObject vue;
 
	float InitialY;
	
	void Start() {
       
		vue = GameObject.Find ("Vue");
		InitialY = vue.transform.position.y;
    }
	
    void OnGUI() {
       //draw the background:
       GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
         GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
 
         //draw the filled-in part:
         GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
          GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
         GUI.EndGroup();
       GUI.EndGroup();
    }
 
    void Update() {
       //for this example, the bar display is linked to the current time,
       //however you would set this value based on your desired display
       //eg, the loading progress, the player's health, or whatever.
       //barDisplay = GameObject.Find("Vue").transform.position.y/InitialY;
		barDisplay = vue.transform.position.y/InitialY;
		
		
		//Debug.Log(InitialY+" altitude "+GameObject.Find("Vue").transform.position.y);
		
//   barDisplay = MyControlScript.staticHealth;
    }
}