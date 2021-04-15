using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public int bScore;
    public int pScore;

    public Text bScoreTxt;
    public Text pScoreTxt;
    public Text timeTxt;
    public Text blueWinTxt;
    public Text purpleWinTxt;
    public Text drawTxt;

    public Button playAgainBtn;
    public Button mainMenuBtn;

    public Button easyBtn;
    public Button mediumBtn;
    public Button hardBtn;

    public GameObject point;
    public GameObject player;
    public Vector3 pos;
    private float rot;

    public int timeLimit;
    public float timeCounter = 0;

    public Button startBtn;
    public Button exitBtn;
    public Button optionBtn;
    public GameObject panel;

    public AudioSource boo;
    public AudioSource cheer;
    public AudioSource scoring;

    public string Challenge;
    public GameObject goalie;
    public GameObject left;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        goalie = GameObject.Find("PurpleStriker (4)");
        left = GameObject.Find("PurpleStriker (1)");
        Challenge = PlayerPrefs.GetString("Player");
        if (Challenge == "1")
        {
            goalie = GameObject.Find("PurpleStriker (4)");
            left = GameObject.Find("PurpleStriker (1)");
            goalie.SetActive(true);
            left.SetActive(true);
            Debug.Log("updaye");
        }
        if (Challenge == "2")
        {
            goalie = GameObject.Find("PurpleStriker (4)");
            left = GameObject.Find("PurpleStriker (1)");
            goalie.SetActive(false);
            left.SetActive(true);
            Debug.Log("updaye");
        }
        if (Challenge == "3")
        {
            goalie = GameObject.Find("PurpleStriker (4)");
            left = GameObject.Find("PurpleStriker (1)");
            goalie.SetActive(false);
            left.SetActive(false);
            Debug.Log("hea");
            Debug.Log("updaye");
        }
        Time.timeScale = 1.0f;
        if (SceneManager.GetActiveScene().name == "Main")
        {
            bScore = 0;
            pScore = 0;
            rot = 0f;
            pos = player.transform.position;
        }
        bScore = 0;
        pScore = 0;
        rot = 0f;
        playAgainBtn.onClick.AddListener(PlayAgain);
        mainMenuBtn.onClick.AddListener(MainMenu);
        pos = player.transform.position;
        //point.transform.localScale = new Vector3(10, 1, 1);
        //Time.timeScale = 2;
    }
    private void FixedUpdate()
    {

        if (SceneManager.GetActiveScene().name == "Main")
        {
            rot += 0.01f;
            point.transform.rotation *= Quaternion.Euler(0, rot, 0);
            timeCounter += Time.fixedDeltaTime;

            if (timeCounter > 1)
            {
                timeLimit -= 1;
                timeTxt.text = "Time : " + timeLimit;
                timeCounter = 0;
            }

            if (timeLimit == 0)
            {
                FinishGame();
            }
        }
    }
    public void Score(AgentSoccer.Team color)
    {
        switch (color)
        {
            case AgentSoccer.Team.Blue:
                bScore += 1;
                Debug.Log("Blue score: " + bScore);
                scoring.Play();
                //SoundManager.PlaySound("score");
                bScoreTxt.text = "Blue: " + bScore.ToString();
                break;
            case AgentSoccer.Team.Purple:
                pScore += 1;
                Debug.Log("Purple score: " + pScore);
                scoring.Play();
                //SoundManager.PlaySound("score");
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
        if (pScore == bScore)
        {
            boo.Play();
            //SoundManager.PlaySound("boo");
            drawTxt.gameObject.SetActive(true);
            playAgainBtn.gameObject.SetActive(true);
            mainMenuBtn.gameObject.SetActive(true);
        }
        else
        {
            if (pScore > bScore)
            {
                cheer.Play();
                //SoundManager.PlaySound("cheer");
                purpleWinTxt.gameObject.SetActive(true);
                playAgainBtn.gameObject.SetActive(true);
                mainMenuBtn.gameObject.SetActive(true);
            }
            else
            {
                boo.Play();
                //SoundManager.PlaySound("boo");
                blueWinTxt.gameObject.SetActive(true);
                playAgainBtn.gameObject.SetActive(true);
                mainMenuBtn.gameObject.SetActive(true);
            }
        }

    }
    public void onClickStartBtn()
    {
        Debug.Log("StartBtn clicekd");
        SceneManager.LoadScene("Main");
    }
    public void onExitBtn()
    {
        Debug.Log("ExitBtn clicekd");
        Application.Quit();

    }
    public void onInstructionBtn()
    {
        Debug.Log("Instruction button clicked");
        if(!panel.active)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void onClickOptionBtn()
    {
        SceneManager.LoadScene("OptionScene");
    }
}
