using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnGUI() {
		GUILayout.BeginArea(new Rect(Screen.width-30,
			Screen.height - 30,
			30,
			30), "", "box");

		string buttonText = GameObject.FindGameObjectsWithTag("Npc").Length.ToString();

		if (GUILayout.Button(buttonText)) {
		}
		GUILayout.EndArea();

	
		GUILayout.BeginArea(new Rect(Screen.width-60,
			Screen.height - 30,
			30,
			30), "", "box");

		buttonText = GameObject.FindGameObjectsWithTag("Player").Length.ToString();

		if (GUILayout.Button(buttonText)) {
		}
		GUILayout.EndArea();
	
	}

}
