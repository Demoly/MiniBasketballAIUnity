using UnityEngine;
using UnityEngine.AI;

public class Ball : MonoBehaviour
{
    public Manager manager;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1") || other.gameObject.CompareTag("Player 2"))
        {
            other.GetComponent<Player>().BallPossession = true;
            //gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }
        else
        {
            //BallPossession = false;
        }
    }
}