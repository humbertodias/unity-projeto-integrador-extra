using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextFadeInOut : MonoBehaviour {


	public Text text;
	public float duration = 0.5f;
	public bool fadeIn = true;
	public bool fadeOut = false;

	void Start(){
		
		if (fadeIn)
			FadeIn ();

		if(fadeOut)
			FadeOut ();

	}

	public void FadeOut()
	{
		StartCoroutine("FadeOutCR");
	}

	public void FadeIn()
	{
		StartCoroutine("FadeInCR");
	}

	private IEnumerator FadeOutCR()
	{
		float currentTime = 0f;
		while(currentTime < duration)
		{
			float alpha = Mathf.Lerp(1f, 0f, currentTime/duration);
			text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
			currentTime += Time.deltaTime;
			yield return null;
		}

//		FadeIn ();

		yield break;
	}

	private IEnumerator FadeInCR()
	{
		float currentTime = 0f;
		while(currentTime < duration)
		{
			float alpha = Mathf.Lerp(0f, 1f, currentTime/duration);
			text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
			currentTime += Time.deltaTime;
			yield return null;
		}

		yield break;

	}


}
