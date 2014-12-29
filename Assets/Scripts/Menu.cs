using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public int window;
	void Start () { 
		window = 1;
	}
	void OnGUI () { 
		GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200)); 
		
		if(window == 1) { 
			if(GUI.Button (new Rect (10,30,180,30), "Play")) 
			{ 
				window = 2;   
			} 
			if(GUI.Button (new Rect (10,150,180,30), "Quit")) 
			{ 
				window = 3; 
			} 
		}
		if (window == 2) {
			Application.LoadLevel(1);		
		}
		if (window == 3) {
			Application.Quit();		
		}
		GUI.EndGroup (); 
		
	} 
}