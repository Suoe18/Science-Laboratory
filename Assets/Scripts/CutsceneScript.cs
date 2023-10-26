using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{
    [SerializeField] private GameObject cameraCutScene;
    [SerializeField] private GameObject firstCutScene;
    [SerializeField] private GameObject timerGameobject;

    [SerializeField] private GameObject innoGameObject;
    [SerializeField] private GameObject questPanel;
    [SerializeField] private GameObject inventoryPanel;

    [SerializeField] private GameObject backgroundMusic;


    [SerializeField] private GameObject firstCamera;
    [SerializeField] private GameObject secondCamera;
    [SerializeField] private GameObject thirdCamera;

    public void Deactivate()
    {
        cameraCutScene.SetActive(false);
        firstCutScene.SetActive(false);
        timerGameobject.SetActive(true);
        questPanel.SetActive(true);
        inventoryPanel.SetActive(true);
        backgroundMusic.SetActive(true);
    }

    public void ActivateHumans()
    {        
        innoGameObject.SetActive(true);
    }

    public void DeactivateHumans()
    {        
        innoGameObject.SetActive(false);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void StopMusic()
    {
        backgroundMusic.SetActive(false);
    }
}
