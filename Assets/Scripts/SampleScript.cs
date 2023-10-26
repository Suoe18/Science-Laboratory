using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScript : MonoBehaviour
{
    public static SampleScript instance;

    private Collider[] interactionCollider;
    [SerializeField] private float interactionRadius;
    [SerializeField] private GameObject messageIndicatorGO;
    [SerializeField] private GameObject sampleGO;

    private bool canInteract;
    public float hasSample = 0;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {        
        SampleColliderFunction();

        if (canInteract)
        {
            if (hasSample < 1 && Input.GetKey(KeyCode.E))
            {
                Destroy(sampleGO);
                InventoryManager.instance.AddItem(0);
                SoundEffectManager.instance.AcquireItemSound();
                hasSample = 1;
            }
        }
    }

    private void SampleColliderFunction()
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
}
