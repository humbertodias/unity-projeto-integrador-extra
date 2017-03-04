using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public int current = 4;
	public AudioClip deadSound;


    public Color color = Color.red;

	private AudioSource audioSource;

	public ParticleSystem deadParticleSystem;

	void Start(){
		audioSource = Camera.main.GetComponent<AudioSource> ();
	}

    // Update is called once per frame
    void Update () {
		
        // set 3d text to '----', '---', '--', '-' or ''
        TextMesh tm = GetComponentInChildren<TextMesh>();
        tm.text = new string('-', current);
        
        // set 3d text color
		tm.GetComponent<Renderer>().material.color = color;
        
        // optional: make it look horizontally by facing the camera
        // (uncomment it to see how it looks otherwise)
        tm.transform.forward = Camera.main.transform.forward;
    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate() {
        // dead?     
        if (current <= 0) {

			if(audioSource!=null)
				audioSource.PlayOneShot(deadSound);

			if (deadParticleSystem != null) {

				//
				ParticleSystem ps = Instantiate (deadParticleSystem, transform.position, transform.rotation);
				ps.Play ();

			}

            Destroy(gameObject);
        }
    }


}
