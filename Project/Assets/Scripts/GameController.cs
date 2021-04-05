using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    private int bScore;
    private int pScore;

    public Text bScoreTxt;
    public Text pScoreTxt;
    public Text timeTxt;
    public Text blueWinTxt;
    public Text purpleWinTxt;
    public Text drawTxt;

    public GameObject point;
    public GameObject player;
    public Vector3 pos;
    private float rot;

    public int timeLimit;
    public float timeCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        bScore = 0;
        pScore = 0;
        rot = 0f;
        

        pos = player.transform.position;
        //point.transform.localScale = new Vector3(10, 1, 1);
        //Time.timeScale = 2;

    }
    private void FixedUpdate()
    {
        rot += 0.01f;
        point.transform.rotation *= Quaternion.Euler(0, rot, 0);
        timeCounter += Time.fixedDeltaTime;

        if(timeCounter > 1)
        {
            timeLimit -= 1;
            timeTxt.text = "Time : " + timeLimit;
            timeCounter = 0;
        }

        if(timeLimit == 0)
        {
            FinishGame();
        }


    }
        public void Score(AgentSoccer.Team color)
    {
        switch(color)
        {
            case AgentSoccer.Team.Blue:
                bScore += 1;
                Debug.Log("Blue score: " + bScore);
                bScoreTxt.text = "Blue: " + bScore.ToString();
                break;
            case AgentSoccer.Team.Purple:
                pScore += 1;
                Debug.Log("Purple score: " + pScore);
                pScoreTxt.text = "Purple: " + pScore.ToString();
                break;
            default:
                break;
        }
        player.transform.position = pos;
        //Debug.Log("is scoring working?");
    }

    private void FinishGame()
    {
        Time.timeScale = 0;
        if(pScore == bScore)
        {
            drawTxt.gameObject.SetActive(true);
        }
        else
        {
            if (pScore > bScore)
            {
                purpleWinTxt.gameObject.SetActive(true);
            }
            else
            {
                blueWinTxt.gameObject.SetActive(true);
            }
        }

    }
}
