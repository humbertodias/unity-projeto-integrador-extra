using UnityEngine;
using System.Collections;

public class AnimationSinus : MonoBehaviour {
    // parâmetros
    float animRemaining = 0.0f;
    public float animSpeed = 20.0f;
    public float intensity = 1.0f;

    // escala inicial
    Vector3 startScale;


	void Start () {
	   startScale = transform.localScale;
	}
	

	void Update () {
        // animacao ainda em progresso?
		if (inProgress ()) {
			animRemaining -= animSpeed * Time.deltaTime;
            
			// calculate current scale:
			//   Mathf.Sin so it goes higher and lower
			//   * intensity so the effect is not too strong
			float s = Mathf.Sin (animRemaining) * intensity;
			transform.localScale = startScale + new Vector3 (s, s, s);
		} else {
			transform.localScale = Vector3.one;
		}
	}

    public void toggle() {
        // inicia nova animacao
        animRemaining = 2 * Mathf.PI;
    }

    public bool inProgress() {
        return animRemaining > 0.0f;
    }
}
