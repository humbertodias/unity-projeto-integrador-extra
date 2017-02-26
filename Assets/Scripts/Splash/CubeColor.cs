using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeColor : MonoBehaviour {

	public GameObject cube;

	public float moveSpeed = 10f;
	public float turnSpeed = 50f;
	public AudioClip rotate;

	private GameObject [] faces;

	void Start () {
		faces = new GameObject[6];
		faces[0] = GameObject.Find ("CubeWithFaces/Back");
		faces[1] = GameObject.Find ("CubeWithFaces/Bottom");
		faces[2] = GameObject.Find ("CubeWithFaces/Front");
		faces[3] = GameObject.Find ("CubeWithFaces/Left");
		faces[4] = GameObject.Find ("CubeWithFaces/Right");
		faces[5] = GameObject.Find ("CubeWithFaces/Top");

		RandomColorFaces ();

	}

	void RandomColorFaces(){

		IEnumerable<Color> colors = GetRandomNumbers(faces.Length);

		int i = 0;
		var enumerator = colors.GetEnumerator();
		while(enumerator.MoveNext())
		{
			Color color = enumerator.Current;
			faces [i++].GetComponent<Renderer> ().material.color = color;
			if (rotate) {
				AudioSource.PlayClipAtPoint (rotate, transform.position, 1f);
			}
		}

	}

	void Update () {
		transform.Rotate( new Vector3(1,1,1) , turnSpeed * Time.deltaTime);
	}

	IEnumerable<Color> GetRandomNumbers(int count)
	{	
		HashSet<Color> randomNumbers = new HashSet<Color>();

		for (int i = 0; i < count; i++) 
			while (!randomNumbers.Add( randomColor() ));

		return randomNumbers;
	}

	Color randomColor(){
		return new Color( Random.value, Random.value, Random.value );
	}
}
