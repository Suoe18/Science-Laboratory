using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuScript : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button exitButton;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playButton.enabled = true;
        exitButton.enabled = true;
    }


    public void PlayButton()
    {
        SceneManager.LoadSceneAsync("MainGame");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
