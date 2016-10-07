using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    public float gameoverdelay = 3;

    public bool scoredp1 = false;
    public bool scoredp2 = false;

    public float scorep1 = 0;
    public float scorep2 = 0;

    public bool ___________________;

    public Text scoretext;
    GameObject scoreGO;

    public Text gameovertext;
    GameObject gameoverGO;

    public float gameover;
    // Use this for initialization
    void Start () {
        scoreGO = GameObject.Find("Score");
        scoretext = scoreGO.GetComponent<Text>();
        scoretext.text = "0 : 0";

        gameoverGO = GameObject.Find("EndGame");
        gameovertext = gameoverGO.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update () {
        if (scoredp1 == true) {
            scoredp1 = false;
            scorep1++;
        }
        else if(scoredp2 == true){
            scoredp2 = false;
            scorep2++;
        }
        scoretext.text = scorep1.ToString() + " : " + scorep2.ToString();


        if (scorep1 == 3 || scorep2 == 3) {
            if (scorep1 > scorep2)
            {
                gameovertext.text = "GAME OVER Player1 Wins!!";
            }
            else {
                gameovertext.text = "GAME OVER Player2 Wins!!";
            }
            Destroy(GameObject.Find("Ball"));
            GameObject.Find("PlayAgain").GetComponent<Renderer>().enabled = true;
            GameObject.Find("PlayAgain").GetComponent<Collider>().enabled = true;
            GameObject.Find("Quit").GetComponent<Renderer>().enabled = true;
            GameObject.Find("Quit").GetComponent<Collider>().enabled = true;
            gameovertext.text = "GAME OVER";
            gameover = Time.time + gameoverdelay;
        }
    }
}
