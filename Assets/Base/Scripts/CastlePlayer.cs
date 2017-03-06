using UnityEngine;
using System.Collections;

public class CastlePlayer : MonoBehaviour {       
    // Note: OnMouseDown only works if object has a collider
    void OnMouseDown() {
        // Somente se a animacao terminou
        if (!GetComponent<AnimationSinus>().inProgress()) {            
            // usa UnitSpawner
            GetComponent<UnitSpawner>().spawn();
        }
    }
}