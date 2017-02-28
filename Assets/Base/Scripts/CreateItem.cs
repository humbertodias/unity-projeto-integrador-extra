using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour {

	// This is the casle prefab, to be set in the inspector
	public GameObject prefab;

	// This holds the game-world instance of the prefab
	GameObject instance;

	public float yAdjust = 0;

	GameManager gameManager;

	void Start(){
		gameManager = FindObjectOfType<GameManager> ();
	}

	void Update() {

		// Is the player currently selectin a place to build the castle? Or in
		// other words, was the instance variable set?
		if (instance != null) {
			// Find out the 3D world coordinates under the cursor
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform.name == "Ground") {
					// Refresh the instance position
					instance.transform.position = hit.point;

					// Note: if your castle appears to be 'in' the Ground
					//       instead of 'on' the ground, you may have to adjust
					//       the y coordinate like so:
//					instance.transform.position += new Vector3(0, 1.23f, 0);
					instance.transform.position += new Vector3(0, yAdjust, 0);
				}
			}

			// Player clicked? Then stop positioning the castle by simply
			// loosing track of our instance. Its still in the game world after-
			// wards, but we just can't position it anymore.
			if (Input.GetMouseButton(0)) {
				instance = null;
			}
		}
	}

	public void Create() {
			// Instantiate the prefab and keep track of it by assigning it to
			// our instance variable.
			instance = (GameObject)GameObject.Instantiate(prefab);

		if (instance != null)
			gameManager.startedGame = true;
		
	}

}