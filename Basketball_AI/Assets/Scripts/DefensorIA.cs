using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensorIA : BaseIA {
    public double defenseAccuracy = 0.3f;

    void Update () {
        if (isPlayer1)
        {
            agent.SetDestination(new Vector3(nest.transform.position.x - 1.5f, 1.25f, manager.ball.transform.position.z));
        }
        else
        {
            agent.SetDestination(new Vector3(nest.transform.position.x + 1.5f, 1.25f, manager.ball.transform.position.z));
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(nest.tag))
        {
            if (opponent.GetComponent<Player>().BallPossession == true 
                && transform.position.z >= opponent.transform.position.z - 3 && transform.position.z <= opponent.transform.position.z + 3
                && transform.position.x >= opponent.transform.position.x - 2 && transform.position.x <= opponent.transform.position.x + 2)
            {
                if (shootingAccuracy == 0)
                {
                    shootingAccuracy = opponent.GetComponent<Player>().shootingAccuracy;
                    opponent.GetComponent<Player>().shootingAccuracy -= defenseAccuracy;
                }

            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(nest.tag))
        {
            if (shootingAccuracy != 0)
            {
                opponent.GetComponent<Player>().shootingAccuracy = shootingAccuracy;
                shootingAccuracy = 0;
            }
        }
    }
}
