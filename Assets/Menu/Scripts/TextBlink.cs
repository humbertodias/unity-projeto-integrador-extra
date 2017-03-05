using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour {

	private Text text;
	public float duration = 0.5f;
	public int times = 0;
	public bool loop = true;

	private float currentTime = 0;

	private float min = 0f;
	private float max = 1f;


	public bool disableAfterTimes = false;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {


		if (times <= 0 && disableAfterTimes) {
			text.enabled = false;
			return;
		}

		if (loop || times > 0) {

			float alpha = Mathf.Lerp (min, max, currentTime / duration);
			text.color = new Color (text.color.r, text.color.g, text.color.b, alpha);
			currentTime += Time.deltaTime;

			if (currentTime > duration) {
				currentTime = 0f;

				if (min == 0f) {
					min = 1f;
					max = 0f;

					times -= 1; 

				} else {
					min = 0f;
					max = 1f;
				}

			} else {
				return;
			}

		}  



	
	}
}
