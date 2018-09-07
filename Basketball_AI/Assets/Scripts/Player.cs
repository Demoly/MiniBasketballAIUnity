using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Player : BaseIA {
    public double stealAccuracy = 0.5;

    private readonly Random random;

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
                if (!tryToSteal && transform.position.z >= opponent.transform.position.z - 1 && transform.position.z <= opponent.transform.position.z + 1
                    && transform.position.x >= opponent.transform.position.x - 1 && transform.position.x <= opponent.transform.position.x + 1)
                {
                    trySteal();
                }

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
    }

    void tryShoot()
    {
        if (Random.Range(0.0f , 1.0f) <= shootingAccuracy)
        {
            manager.setScore(isPlayer1);
        } else if (isPlayer1)
        {
            //manager.ballAgent.SetDestination(new Vector3(-6, 0.5f, Random.Range(-9.0f, 9.0f)));
            manager.ball.transform.position = new Vector3(-6, 0.5f, Random.Range(-10.0f, 10.0f));
            BallPossession = false;
        } else
        {
            //manager.ballAgent.SetDestination(new Vector3(6, 0.5f, Random.Range(-9.0f, 9.0f)));
            manager.ball.transform.position = new Vector3(6, 0.5f, Random.Range(-10.0f, 10.0f));
            BallPossession = false;
        }
    }

    void trySteal()
    {
        if (Random.Range(0.0f, 1.0f) <= shootingAccuracy)
        {
            manager.ball.transform.position = transform.position;
            opponent.GetComponent<Player>().BallPossession = false;

            opponent.GetComponent<Player>().tryToSteal = true;
            opponent.GetComponent<Player>().StartCoroutine("enumeratorSteal");

            BallPossession = true;

        }
        tryToSteal = true;
        StartCoroutine("enumeratorSteal");
    }

    IEnumerator enumeratorSteal()
    {
        // suspend execution for 3 seconds
        yield return new WaitForSeconds(3);
        tryToSteal = false;
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
}