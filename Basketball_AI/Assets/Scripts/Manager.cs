using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
    public Text textScore1;
    public int  score1;
    public Text textScore2;
    public int score2;

    public GameObject ball;
    public Player player1;
    public Player player2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setScore(bool isScore1)
    {
        if (isScore1)
        {
            score1++;
            textScore1.text = score1 + "";

            player1.Reset();
            player2.Reset();
            ball.transform.position = new Vector3(-3,1,3);
        } else
        {
            score2++;
            textScore2.text = score2 + "";

            player1.Reset();
            player2.Reset();
            ball.transform.position = new Vector3(3, 1, -3);

        }
    }
}
