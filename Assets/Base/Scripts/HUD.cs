using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

	public GameObject panelWon;
	public GameObject pagelLose;

	GameManager gameManager;


	void Awake(){
		gameManager = FindObjectOfType<GameManager> ();
		gameManager.startedGame = false;
	}
		

	void OnGUI() {

		int npcs = GameObject.FindGameObjectsWithTag ("Npc").Length;
		int players = GameObject.FindGameObjectsWithTag("Player").Length;


		if (gameManager.startedGame) {
			if (npcs == 0)
				panelWon.SetActive (true);

			if (players == 0)
				pagelLose.SetActive (true);
		}

		// Npcs



		GUILayout.BeginArea(new Rect(Screen.width-50,
			Screen.height - 30,
			50,
			30), "", "none");

		GUI.contentColor = Color.red;
		if (GUILayout.Button(npcs.ToString())) {
		}
		GUILayout.EndArea();
		// Npcs

		// Players	
		GUILayout.BeginArea(new Rect(Screen.width-100,
			Screen.height - 30,
			50,
			30), "", "none");

		GUI.contentColor = Color.blue;

		if (GUILayout.Button(players.ToString())) {
		}
		GUILayout.EndArea();
		// Players	
	
	}

}
