using UnityEngine;
using System.Collections;




public class Menu : MonoBehaviour {
	
	public Font fontFamily;
	public Color color;
	GUIStyle titleStyle;
	GUIStyle levelStyle;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	 void OnGUI() {
		
		titleStyle = new GUIStyle();
		
		titleStyle.fontSize = 100;
		titleStyle.font = fontFamily;
		titleStyle.normal.textColor = Color.red;
		
        GUI.Label(new Rect(Screen.width/2 -400, 100, 100, 20), "Projet Base Jump",titleStyle);
		
		
	/*	Color c = new Color(0.5f,0.1f,0.1f);
		levelStyle = new GUIStyle();
		levelStyle.fontSize = 50;
		levelStyle.font = fontFamily;
		levelStyle.normal.textColor =  c;
		
		GUI.Label(new Rect(300, 200, 100, 20), "Niveau 1",levelStyle);
		GUI.Label(new Rect(300, 300, 100, 20), "Niveau 2",levelStyle);
	*/
	
    }
		
	
}
