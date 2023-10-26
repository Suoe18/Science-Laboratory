using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabcoatScript : MonoBehaviour
{
    public static LabcoatScript instance;

    private Collider[] interactionCollider;
    [SerializeField] private float interactionRadius;
    [SerializeField] private GameObject messageIndicatorGO;
    [SerializeField] private GameObject labcoatGO;

    private bool canInteract;
    public float hasLabcoat = 0;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        LabCoatColliderFunction();

        if(canInteract)
        {
            if(hasLabcoat < 1 && Input.GetKey(KeyCode.E))
            {                
                Destroy(labcoatGO);
                InventoryManager.instance.AddItem(2);
                SoundEffectManager.instance.AcquireItemSound();
                hasLabcoat = 1;
            }
        }
    }

    private void LabCoatColliderFunction()
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
