using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject strText;

    public static float theScore;
    public static float theTime = 100;

    private float scorePerSec = 10f;
    private float timePerSec = 2f;


    void Update()
    {
        theScore += scorePerSec * Time.deltaTime;
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score : " + (int)theScore;

        theTime -= timePerSec * Time.deltaTime;
        strText.GetComponent<UnityEngine.UI.Text>().text = "Time : " + (int)theTime;
        GameOverCheck();

        

    }

    public void GameOverCheck()
    {
        if (theTime <= 0)
        {
            Application.Quit(); 
        }
    }
}
