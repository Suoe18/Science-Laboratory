using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TaskManagerScript : MonoBehaviour
{
    public static TaskManagerScript instance;

    [SerializeField] private TMP_Text taskOne;
    [SerializeField] private TMP_Text taskTwo;
    [SerializeField] private TMP_Text taskThree;
    [SerializeField] private TMP_Text taskFour;
    [SerializeField] private TMP_Text taskFive;
    [SerializeField] public TMP_Text taskSix;

    [SerializeField] private GameObject scopeCamera;
    [SerializeField] private GameObject finalCutScene;

    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject timeManager;
    [SerializeField] private GameObject taskManager;

    public float hasMicroscope = 0;

    private float taskNumber;
    public float taskCompleted = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        taskNumber = 6;
    }

    void Update()
    {
        CheckTaskCompleted();

        if (taskCompleted >= taskNumber)
        {
            scopeCamera.SetActive(false);
            timeManager.SetActive(false);
            taskManager.SetActive(false);
            inventoryPanel.SetActive(false);
            finalCutScene.SetActive(true);
        }
    }

    private void CheckTaskCompleted()
    {
        if (LabcoatScript.instance.hasLabcoat == 1)
        {
            taskOne.fontStyle = FontStyles.Strikethrough;
            taskCompleted++;
            LabcoatScript.instance.hasLabcoat = 3;
        }

        if (GogglesScript.instance.hasGoggles == 1)
        {
            taskTwo.fontStyle = FontStyles.Strikethrough;
            taskCompleted++;
            GogglesScript.instance.hasGoggles = 3;
        }

        if(MicroscopeTableScript.instance.microscopeIsPresent)
        {
            taskThree.fontStyle = FontStyles.Strikethrough;
            taskCompleted++;
            MicroscopeTableScript.instance.microscopeIsPresent = false;
            hasMicroscope = 3;
        }

        if(SampleScript.instance.hasSample == 1)
        {
            taskFour.fontStyle = FontStyles.Strikethrough;
            taskCompleted++;
            SampleScript.instance.hasSample = 3;
        }

        if (MicroscopeTableScript.instance.sampleIsPlaced)
        {
            taskFive.fontStyle = FontStyles.Strikethrough;
            MicroscopeTableScript.instance.sampleIsPlaced = false;
            taskCompleted++;            
        }

        

        
        
    }
}
