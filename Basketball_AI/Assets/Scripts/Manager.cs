using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System.Collections.Generic;

public class Manager : MonoBehaviour {
    public TextMeshProUGUI textScore1;
    public int  score1;
    public TextMeshProUGUI textScore2;
    public int score2;

    public GameObject ball;
    //public NavMeshAgent ballAgent;
    public List<BaseIA> listIA;

    public int ballPossesion;

    private void Start()
    {
        //ballAgent = ball.GetComponent<NavMeshAgent>();
        //ballAgent.radius = 0;
    }

    public void setScore(bool isScore1)
    {
        if (isScore1)
        {
            score1++;
            textScore1.text = score1 + "";

            ball.transform.position = new Vector3(-6,1,6);
        } else
        {
            score2++;
            textScore2.text = score2 + "";
            
            ball.transform.position = new Vector3(6, 1, -6);
        }

        //ballAgent.isStopped = true;

        foreach (BaseIA p in listIA)
        {
            p.Reset();
        }
    }
}
