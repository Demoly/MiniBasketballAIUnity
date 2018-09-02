using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
    public Camera cam;

    public NavMeshAgent agent;

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("macaco");

            if (Physics.Raycast(ray, out hit)) 
            {
                Debug.Log("hit " + hit.point);
                // Move agent
                agent.SetDestination(hit.point);
            }

        }
	}
}
