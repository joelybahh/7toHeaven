using UnityEngine;
using System.Collections;

public class TempEnemyFollow : MonoBehaviour {

    public enum eFollowBevaviour {
        BASIC,
        FLANK,
        IGNOREWALLS
    }

    public eFollowBevaviour behaviour = eFollowBevaviour.BASIC;

    NavMeshAgent agent;

	void Awake () {
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        switch (behaviour) {
            case eFollowBevaviour.BASIC:
                agent.SetDestination(GameObject.Find("FPSController").transform.position);
                break;
            case eFollowBevaviour.FLANK:
                agent.SetDestination(GameObject.Find("FPSController").transform.FindChild("flankDest").position);
                break;
            case eFollowBevaviour.IGNOREWALLS:

                break;
        }
	}
}
