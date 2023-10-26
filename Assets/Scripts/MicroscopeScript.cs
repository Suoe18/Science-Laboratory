using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeScript : MonoBehaviour
{
    public static MicroscopeScript instance;

    private Collider[] interactionCollider;
    [SerializeField] private float interactionRadius;
    [SerializeField] private GameObject messageIndicatorGO;
    [SerializeField] private GameObject microscopeGO;

    private bool canInteract;
    private bool canGetMicroscope;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(CorrectCabinetDoor.instance.isDoorOpen)
        {
            StartCoroutine(Delay());
        }

        if(canGetMicroscope)
        {
            MicroscopeColliderFunction();
        }
        

        if (canInteract)
        {
            if (TaskManagerScript.instance.hasMicroscope < 1 && Input.GetKey(KeyCode.E))
            {
                Destroy(microscopeGO);
                InventoryManager.instance.AddItem(3);
                SoundEffectManager.instance.AcquireItemSound();
                TaskManagerScript.instance.hasMicroscope = 1;
            }
        }
    }

    private void MicroscopeColliderFunction()
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
        yield return new WaitForSeconds(1);
        canGetMicroscope = true;
    }
}
