using UnityEngine;

public class SoccerBallController : MonoBehaviour
{
    [HideInInspector]
    public SoccerFieldArea area;
    public string purpleGoalTag; //will be used to check if collided with purple goal
    public string blueGoalTag; //will be used to check if collided with blue goal
    private GameObject gcO;
    private GameController gc;

    private void Start()
    {
        gcO = GameObject.Find("GameController");
        gc = gcO.GetComponent<GameController>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(purpleGoalTag)) //ball touched purple goal
        {
            area.GoalTouched(AgentSoccer.Team.Blue);
            Debug.Log("Purple got goal");
            gc.Score(AgentSoccer.Team.Blue);

        }
        if (col.gameObject.CompareTag(blueGoalTag)) //ball touched blue goal
        {
            area.GoalTouched(AgentSoccer.Team.Purple);
            gc.Score(AgentSoccer.Team.Purple);
            Debug.Log("Blue got goal");
        }
    }
}
