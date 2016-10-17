using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    public float gameoverdelay = 3;

    public bool fourplayer;

    public bool scoredp1 = false;
    public bool scoredp2 = false;

    public float scorep1 = 0;
    public float scorep2 = 0;

    public bool ___________________;

    public Text scoretext_P1;
	public Text scoretext_P2;

    public Text gameovertext;
    GameObject gameoverGO;

    public float gameover;
    // Use this for initialization
    void Start () {
		scoretext_P1 = GameObject.Find ("Score_P1").GetComponent<Text> ();
		scoretext_P2 = GameObject.Find ("Score_P2").GetComponent<Text> ();

		scoretext_P1.text = "0";
		scoretext_P2.text = "0";

        gameoverGO = GameObject.Find("EndGame");
        gameovertext = gameoverGO.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update () {
        if (scoredp1 == true) {
            scoredp1 = false;
            scorep1++;
			scoretext_P1.text = scorep1.ToString ();
        }
        else if(scoredp2 == true){
            scoredp2 = false;
            scorep2++;
			scoretext_P2.text = scorep2.ToString ();
        }


        if (scorep1 == 3 || scorep2 == 3) {
            if (scorep1 > scorep2)
            {
                gameovertext.text = "GAME OVER Player1 Wins!!";
                if (fourplayer) {
                    gameovertext.text = "GAME OVER TEAM 1 Wins!!";
                }
            }
            else {
                gameovertext.text = "GAME OVER Player2 Wins!!";
                if (fourplayer)
                {
                    gameovertext.text = "GAME OVER TEAM 2 Wins!!";
                }
            }
            Destroy(GameObject.Find("Ball"));
            GameObject.Find("PlayAgain").GetComponent<Renderer>().enabled = true;
            GameObject.Find("PlayAgain").GetComponent<Collider>().enabled = true;
            GameObject.Find("Quit").GetComponent<Renderer>().enabled = true;
            GameObject.Find("Quit").GetComponent<Collider>().enabled = true;
            gameover = Time.time + gameoverdelay;
        }
    }
}
