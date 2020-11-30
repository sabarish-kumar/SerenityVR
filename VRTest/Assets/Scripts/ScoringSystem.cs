using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject fuelText;
    public GameObject healthText;
    public static float theScore;
    public static float theFuel=100;
    public static float theHealth = 100;
    private float scorePerSec = 10f;
    private float fuelPerSec = 10f;
    private float healthPerSec = 1f;

    void Update()
    {
        theScore += scorePerSec * Time.deltaTime;
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score : " + (int)theScore;
        
        theFuel -= fuelPerSec * Time.deltaTime;
        fuelText.GetComponent<TextMeshProUGUI>().text = "Fuel : " + (int)theFuel;
        GameOverCheck(); 

        /*healthText.GetComponent<TextMeshProUGUI>().text = "Health : " + (int)theHealth;
        Debug.Log(theHealth);*/
    }

    public void GameOverCheck()
    {
        if (theFuel <= 0 || theHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
