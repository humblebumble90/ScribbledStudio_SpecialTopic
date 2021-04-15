using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void easyDiff()
    {
        PlayerPrefs.SetString("Player", "1");
        Debug.Log("easy");
        SceneManager.LoadScene("Main");
    }
    public void mediumDiff()
    {
        PlayerPrefs.SetString("Player", "2");
        Debug.Log("easy");
        SceneManager.LoadScene("Main");
    }
    public void hardDiff()
    {
        PlayerPrefs.SetString("Player", "3");
        Debug.Log("easy");
        SceneManager.LoadScene("Main");
    }
}
