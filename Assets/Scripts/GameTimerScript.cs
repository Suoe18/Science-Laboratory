using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimerScript : MonoBehaviour
{    
    [SerializeField] private TMP_Text textDisplay;

    public int minutesLeft = 2;
    public int secondsLeft = 0;
    public bool isPlaying = false;

    bool minutesIsDone = false;
    bool secondIsDone = false;

    public bool gameIsDone = false;

    void Start()
    {
        textDisplay.text = "Time Left: " + minutesLeft + ":0" + secondsLeft;        
    }


    void Update()
    {
        // Booleans for Timer Logic
        if (minutesLeft == 0)
        {
            if (secondsLeft == 0)
            {
                minutesIsDone = true;
                secondIsDone = true;
                gameIsDone = true;
            }
        }

        if (!isPlaying && !minutesIsDone && !secondIsDone)
        {
            StartCoroutine(gameTimer());
        }

        if(gameIsDone)
        {
            SceneManager.LoadSceneAsync("GameOver");
        }
    }

    IEnumerator gameTimer()
    {
        isPlaying = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (minutesLeft > 0 && secondsLeft < 0)
        {
            minutesLeft -= 1;
            secondsLeft = 59;

            if (secondsLeft < 10)
            {
                textDisplay.text = "Time Left: " + minutesLeft + ":0" + secondsLeft;
            }
            else
            {
                textDisplay.text = "Time Left: " + minutesLeft + ":" + secondsLeft;
            }
        }
        else
        {
            if (secondsLeft < 10)
            {
                textDisplay.text = "Time Left: " + minutesLeft + ":0" + secondsLeft;
            }
            else
            {
                textDisplay.text = "Time Left: " + minutesLeft + ":" + secondsLeft;
            }
        }

        isPlaying = false;
    }
}
