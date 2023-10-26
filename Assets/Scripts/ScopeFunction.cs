using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScopeFunction : MonoBehaviour
{
    public static ScopeFunction instance;

    [SerializeField] private GameObject cameraView;
    [SerializeField] private GameObject instructionToZoom;

    private bool canZoom;

    private Vector3 cameraInitialPosition;
    private Vector3 cameraYPos;

    private bool letsZoom;
    public float numberOfZoom = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cameraInitialPosition = cameraView.transform.position;
        cameraYPos.y = cameraInitialPosition.y;
    }
    
    void Update()
    {
        if(MicroscopeTableScript.instance.isViewing)
        {
            if(!letsZoom)
            {
                StartCoroutine(Delay());
            }
            else
            {                
                if (canZoom && Input.GetKeyDown(KeyCode.E))
                {
                    if(numberOfZoom < 2)
                    {
                        cameraYPos.y -= 0.4f;
                        canZoom = false;
                        instructionToZoom.SetActive(false);
                    }
                    else
                    {                        
                        cameraYPos.y -= 0.1f;
                        StartCoroutine(DelayVictory());
                    }                    
                    
                    cameraView.transform.position = new Vector3(cameraInitialPosition.x, cameraYPos.y, cameraInitialPosition.z);
                    numberOfZoom++;                    
                }
                else
                {
                    StartCoroutine(DelayScope());
                }
            }           
        }
        
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        instructionToZoom.SetActive(true);
        letsZoom = true;
        canZoom = true;
    }

    private IEnumerator DelayScope()
    {
        yield return new WaitForSeconds(0.5f);
        instructionToZoom.SetActive(true);        
        canZoom = true;
    }

    private IEnumerator DelayVictory()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(instructionToZoom);
        TaskManagerScript.instance.taskSix.fontStyle = FontStyles.Strikethrough;
        TaskManagerScript.instance.taskCompleted++;
    }

    
}
