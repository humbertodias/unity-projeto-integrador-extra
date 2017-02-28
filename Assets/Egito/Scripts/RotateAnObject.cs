using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnObject : MonoBehaviour {

	public Vector3 rotation;

	public float velocidade;

	void Update () {
		transform.localEulerAngles = new Vector3 (rotation.x, transform.localEulerAngles.y + 1f, rotation.z);
	}
}
