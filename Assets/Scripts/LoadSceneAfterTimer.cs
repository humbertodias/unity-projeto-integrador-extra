using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneAfterTimer : MonoBehaviour {


	public float seconds = 10f;
	public string sceneName;

	private float currentTime = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (currentTime > seconds) {
			currentTime = 0;

//			DontDestroyOnLoad(SceneManager.GetActiveScene ());
//			SceneManager.UnloadScene (SceneManager.GetActiveScene ().buildIndex);
			SceneManager.LoadScene (sceneName);
		}

		currentTime += Time.deltaTime;
	}
}
