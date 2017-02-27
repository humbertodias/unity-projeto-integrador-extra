using UnityEngine;
using System.Collections;

public class CastleNpc : MonoBehaviour {
    // Parameters
    public float spawnInterval = 3.0f;
    float spawnIntervalElapsed = 0.0f;
	public int spawnMaxNpcs = 15;

    void Update() {

		int npcs = GameObject.FindGameObjectsWithTag ("Npc").Length;
		if (npcs <= spawnMaxNpcs) {
			
			// Build it every few seconds
			spawnIntervalElapsed += Time.deltaTime;
			if (spawnIntervalElapsed >= spawnInterval) {
				// Use UnitSpawner
				GetComponent<UnitSpawner> ().spawn ();

				// Reset interval
				spawnIntervalElapsed = 0.0f;
			}

		}
    }
}