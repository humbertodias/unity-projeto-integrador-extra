using UnityEngine;
using System.Collections;

public class CastleNpc : MonoBehaviour {
    // Parametros
    public float spawnInterval = 3.0f;
    float spawnIntervalElapsed = 0.0f;
	public int spawnMaxNpcs = 15;

    void Update() {

		int npcs = GameObject.FindGameObjectsWithTag ("Npc").Length;
		if (npcs <= spawnMaxNpcs) {
			
			// Construi a cada poucos segundos
			spawnIntervalElapsed += Time.deltaTime;
			if (spawnIntervalElapsed >= spawnInterval) {
				// Use UnitSpawner
				GetComponent<UnitSpawner> ().spawn ();

				// Reinicia intervalo
				spawnIntervalElapsed = 0.0f;
			}

		}
    }
}