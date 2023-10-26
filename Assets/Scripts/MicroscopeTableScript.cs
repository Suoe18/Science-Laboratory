using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeTableScript : MonoBehaviour
{
    public static MicroscopeTableScript instance;

    private Collider[] interactionCollider;
    [SerializeField] private float interactionRadius;
    [SerializeField] private GameObject messageIndicatorGO;
    [SerializeField] private GameObject microscopeGO;

    [SerializeField] private GameObject bacteriaGO;
    [SerializeField] private GameObject cameraGO;
    [SerializeField] private GameObject cameraCutScene;

    private bool canInteract;
    public bool microscopeIsPresent;

    public bool sampleIsPlaced;

    private bool canViewMicroscope;
    public bool isViewing;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {        
        if (TaskManagerScript.instance.hasMicroscope == 1 || SampleScript.instance.hasSample == 3)
        {
            MicroscopeTableColliderFunction();
        }
        
        if(canViewMicroscope)
        {
            MicroscopeTableColliderFunction();
        }


        if (canInteract)
        {
            if (TaskManagerScript.instance.hasMicroscope == 1 && Input.GetKey(KeyCode.E))
            {
                microscopeGO.SetActive(true);
                InventoryManager.instance.RemoveItem("Microscope");
                SoundEffectManager.instance.DropItemSound();
                microscopeIsPresent = true;                
            }

            if (SampleScript.instance.hasSample == 3 && Input.GetKey(KeyCode.E))
            {
                sampleIsPlaced = true;
                SampleScript.instance.hasSample = 5;
                InventoryManager.instance.RemoveItem("Flask");
                SoundEffectManager.instance.DropItemSound();
                bacteriaGO.SetActive(true);
                StartCoroutine(Delay());
            }            

            if(canViewMicroscope && Input.GetKey(KeyCode.E))
            {
                cameraCutScene.SetActive(true);
                cameraGO.SetActive(true);
                canViewMicroscope = false;
                isViewing = true;
            }
        }


    }

    private void MicroscopeTableColliderFunction()
    {
        interactionCollider = Physics.OverlapSphere(transform.position, interactionRadius);

        foreach (var colliderForInteraction in interactionCollider)
        {
            if (colliderForInteraction.tag == "Player")
            {
                messageIndicatorGO.SetActive(true);
                canInteract = true;
            }
            else
            {
                messageIndicatorGO.SetActive(false);
                canInteract = false;
            }

        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);        
        canViewMicroscope = true;
    }
}
