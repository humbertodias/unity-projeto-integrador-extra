using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace UI {

	public class SplashScreen: MonoBehaviour {

		public event Action EventComplete;

		[SerializeField]
		private Text startText;

		[SerializeField]
		private AudioClip music;

		[SerializeField]
		private AudioClip startSFX;


		public String nextSceneName;

		private bool isComplete;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {


		}

		/// <summary>
		/// OnEnable.
		/// </summary>
		void OnEnable() {
			isComplete = false;
//			AudioManager.Instance.PlayMusic( music );
		}

		/// <summary>
		/// Update.
		/// </summary>
		void Update() {
			if( !isComplete ) {
				// KeyBoard
				if( Input.GetKeyDown( KeyCode.Space ) ) {
					StartPressed();
				}
				// Mouse
				if( Input.GetMouseButtonDown( 0 ) ){
					StartPressed();
				}
			}
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		//===================================================
		// PRIVATE METHODS
		//===================================================

		/// <summary>
		/// Dispatches complete when SPACE is Pressed.
		/// </summary>
		public void StartPressed() {
			isComplete = true;

			SceneManager.LoadScene (nextSceneName);

//			AudioManager.Instance.PlaySFX( startSFX );

			if( EventComplete != null ) {
				EventComplete();
			}
		}

		//===================================================
		// EVENTS METHODS
		//===================================================

	}
}