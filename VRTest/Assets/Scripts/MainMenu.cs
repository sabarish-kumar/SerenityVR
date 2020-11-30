using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("PickupTest");
        ScoringSystem.theScore = 0;
        ScoringSystem.theFuel = 100;    
        //ScoringSystem.theHealth = 100;
}
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();

    }
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("Volume", volume);
        //audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }
}
