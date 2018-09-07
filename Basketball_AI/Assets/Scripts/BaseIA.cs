using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseIA : MonoBehaviour {
    public Manager manager;

    public double shootingAccuracy;
    public bool tryToSteal = false;
    public GameObject nest;
    public GameObject opponentNest;
    public GameObject opponent;
    public bool isPlayer1;

    public NavMeshAgent agent;
    public bool BallPossession;
    public Vector3 initialPosition;
    public Vector3 target;

    // Use this for initialization
    void Start () {
        agent = this.GetComponent<NavMeshAgent>();
        initialPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reset()
    {
        BallPossession = false;
        tryToSteal = false;
        transform.position = initialPosition;
    }
}
