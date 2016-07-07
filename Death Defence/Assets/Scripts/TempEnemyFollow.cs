using UnityEngine;
using System.Collections;

public class TempEnemyFollow : MonoBehaviour {
    NavMeshAgent agent;

	void Awake () {
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(GameObject.Find("FPSController").transform.position);
	}
}
