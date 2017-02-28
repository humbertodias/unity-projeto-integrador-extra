using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadSceneWithSound: MonoBehaviour {

	public string sceneName;
	public AudioClip playSound;

	public float timeOutAutoStart = -1;
	public float startSoundDelay = -1f;

	private float currentTime = 0;


	void Update(){
		
		if (Input.GetMouseButtonDown (0)) 
			play ();


		if (startSoundDelay >= 0 && currentTime > startSoundDelay) {

			startSoundDelay = -1;
			StartCoroutine ( playSoundWaiting (false) );

		}


		if (timeOutAutoStart >= 0 && currentTime > timeOutAutoStart) {

			timeOutAutoStart = -1;
			StartCoroutine ( playSoundWaiting (true) );

		}


		currentTime += Time.deltaTime;
	}


	IEnumerator playSoundWaiting(bool loadScene = false) {
		AudioSource.PlayClipAtPoint (playSound, Vector3.zero, 1f);
		yield return new WaitForSeconds (playSound.length);

		Debug.Log ("PlaySound");
		if(loadScene)
		SceneManager.LoadScene (sceneName);

	}

	public void play(){
		if (playSound) 
			StartCoroutine ( playSoundWaiting (true) );
		else 
			SceneManager.LoadScene (sceneName);

	}

}
