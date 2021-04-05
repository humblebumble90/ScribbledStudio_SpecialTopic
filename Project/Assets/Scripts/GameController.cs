using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    private int bScore;
    private int pScore;
    public Text bScoreTxt;
    public Text pScoreTxt;
    public GameObject point;
    private float rot;
    // Start is called before the first frame update
    void Start()
    {
        bScore = 0;
        pScore = 0;
        rot = 0f;
        //point.transform.localScale = new Vector3(10, 1, 1);

    }
    private void FixedUpdate()
    {
        rot += 0.01f;
        point.transform.rotation *= Quaternion.Euler(0, rot, 0);
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
        //Debug.Log("is scoring working?");
    }
}
