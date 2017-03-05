using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {


	// General audio/sfx files
	public AudioMixer masterMixer;
	public AudioClip companySFX;
	public AudioClip setSFX;
	public AudioClip cancelSFX;

	// Button Sound config
	private bool soundButtonIsPlaying = true;
	public Button soundButton;
	public Sprite soundButtonOn;
	public Sprite soundButtonOff;

	public bool startedGame = false;



	private bool pauseButtonIsPaused = true;
	public Button pauseButton;
	public Sprite pauseButtonOn;
	public Sprite pauseButtonOff;


	public GameObject panelPause;

	void Awake(){
		DontDestroyOnLoad(gameObject);
	}

	public void PlayScene(String sceneName){
		Debug.Log ("PlayScene " + sceneName);
		SceneManager.LoadScene (sceneName);
	}

	public void PlaySFX( AudioClip audio){
		float audioSize = audio.length;
		Camera.main.GetComponent<AudioSource>().PlayOneShot(audio);
		StartCoroutine("WaitSeconds",audioSize);
	}

	IEnumerator WaitSeconds(float seconds){
		yield return new WaitForSeconds(seconds);
	}

	private void SetMasterMixer(float volumeMasterMixer){
		masterMixer.SetFloat("volumeMasterMixer",volumeMasterMixer);
	}

	public void SetSoundOnOff(){
		Debug.Log ("SetSoundOnOff");
		if(soundButtonIsPlaying){
			// mute mixer
			masterMixer.SetFloat("VolumeMasterMixer",-80f);
			soundButtonIsPlaying = !soundButtonIsPlaying;
			soundButton.GetComponent<Image>().sprite = soundButtonOff;
		} else {
			// normal volume
			masterMixer.SetFloat("VolumeMasterMixer",0f);
			soundButtonIsPlaying = !soundButtonIsPlaying;
			soundButton.GetComponent<Image>().sprite = soundButtonOn;
		}
	}


	public void SetPauseOnOff(){
		if(pauseButtonIsPaused){
			// pause
			Time.timeScale = 0f;
			pauseButtonIsPaused = !pauseButtonIsPaused;
			pauseButton.GetComponent<Image>().sprite = pauseButtonOff;
		} else {
			// unpause
			Time.timeScale = 1f;
			pauseButtonIsPaused = !pauseButtonIsPaused;
			pauseButton.GetComponent<Image>().sprite = pauseButtonOn;
		}
	}


	public void PausePanel(){
		SetPauseOnOff ();
		panelPause.SetActive (true);
	}

	public void Resume(){
		SetPauseOnOff ();
		panelPause.SetActive (false);

	}

}