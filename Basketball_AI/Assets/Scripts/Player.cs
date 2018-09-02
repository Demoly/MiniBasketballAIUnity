using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {
    public Manager manager;

    public double shootingAccuracy;
    public GameObject nest;
    public GameObject opponentNest;
    public GameObject opponent;
    public bool isPlayer1;

    private NavMeshAgent agent;
    private bool BallPossession;
    private Vector3 initialPosition;
    private Vector3 target;

    private readonly Random random;

    // Use this for initialization
    void Start () {
        agent = this.GetComponent<NavMeshAgent>();
        initialPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (BallPossession)
        {
            agent.SetDestination(opponentNest.transform.position);
            manager.ball.transform.position = transform.position;
        } else
        {
            if (opponent.GetComponent<Player>().BallPossession)
            {
                defend();
            } else
            {
                agent.SetDestination(manager.ball.transform.position);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (BallPossession && other.gameObject.CompareTag(opponentNest.tag))
        {
            tryShoot();
        } else if (!BallPossession && other.gameObject.CompareTag(opponent.tag) && other.GetComponent<Player>().BallPossession == true)
        {
            trySteal();
        }

        if (other.gameObject.CompareTag("Ball"))
        {
            BallPossession = true;
        } else
        {
            BallPossession = false;
        }
    }

    void tryShoot()
    {
        if(Random.Range(0.0f , 1.0f) <= shootingAccuracy)
        manager.setScore(isPlayer1);
    }

    void trySteal()
    {

    }

    void defend()
    {
        if (isPlayer1)
        {
            target = new Vector3(nest.transform.position.x - 1, transform.position.y, manager.ball.transform.position.z);
        }
        else
        {
            target = new Vector3(nest.transform.position.x + 1, transform.position.y, manager.ball.transform.position.z);
        }

        agent.SetDestination(target);
    }

    public void Reset()
    {
        BallPossession = false;
        transform.position = initialPosition;
    }
}