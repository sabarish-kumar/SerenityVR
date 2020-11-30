using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    private AudioSource source;
    public AudioClip buttonSound;

    private bool on = false;
    private bool buttonHit = false;
    private GameObject button;

    private float buttonDownDis = 0.025f;
    private float buttonReturnSpeed = 0.001f;
    private float buttonOriginalY;

    

    private float buttonHitAgainTime = 0.05f;
    private float canHitAgain;

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();

        button = transform.GetChild(0).gameObject;
        buttonOriginalY = button.transform.position.y;

        

    }

    // Update is called once per frame
    void Update()
    {
        if(buttonHit == true)
        {
            source.PlayOneShot(buttonSound);
            buttonHit = false;

            on = !on;

            button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y - buttonDownDis, button.transform.position.z);

            if(on)
            {
                Application.Quit();

            }
            
        }

        if (button.transform.position.y < buttonOriginalY)
        {
            button.transform.position += new Vector3(0, buttonReturnSpeed, 0);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand")&& canHitAgain<Time.time)
        {
            canHitAgain = Time.time + buttonHitAgainTime;
            buttonHit = true;
        }
    }
}
