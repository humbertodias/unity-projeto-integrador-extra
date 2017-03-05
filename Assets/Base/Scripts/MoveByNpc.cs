using UnityEngine;
using System.Collections;

public class MoveByNpc : MonoBehaviour {

	// A cada frame
	void Update () {
        // pega intervalo de ataque
        float range = GetComponent<Attack>().range;

        // encontra inimigos
        string enemyTag = GetComponent<Attack>().enemyTag;
        GameObject[] units = GameObject.FindGameObjectsWithTag(enemyTag);
        
        // se tem algum atacando? entao, nao tem que atacar
        foreach (GameObject g in units) {
            // ainda vido?
            if (g != null) {
                if (Vector3.Distance(transform.position, g.transform.position) <= range) {
                    return;
                }
            }
        }

        // ja esta se movendo? então não faça nada
        if (GetComponent<UnityEngine.AI.NavMeshAgent>().hasPath) {
            return;
        }


        // pega um alvo aleatorio (se houver algum)
        if (units.Length > 0) {
            int index = Random.Range(0, units.Length);
            GameObject u = units[index];
            
            // ainda tem vida?
            if (u != null) {
                // mova proximo o suficiente para atacar
                Vector3 pos = transform.position;
                Vector3 target = u.transform.position;
                
                Vector3 dir = target - pos;
                dir = dir.normalized;
                Vector3 dest = pos + dir * (Vector3.Distance(target, pos) - range);

                // fala para o agente da navmesh ir até lá
				GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(dest);

            }
        }
	}
}
