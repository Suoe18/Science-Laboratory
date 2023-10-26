using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetScript : MonoBehaviour
{
    public static CabinetScript instance;

    private Collider[] interactionCollider;
    [SerializeField] private float interactionRadius;
    [SerializeField] private GameObject messageIndicatorGO;
    [SerializeField] private GameObject cabinetDoor;    

    private bool canInteract;
    private bool colliderFunctionActive = true;
    public bool isDoorOpen;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(colliderFunctionActive)
        {
            CabinetColliderFunction();
        }
        

        if (canInteract)
        {
            if (Input.GetKey(KeyCode.E) && !isDoorOpen)
            {
                SoundEffectManager.instance.DoorCabinetOpen();
                CabinetDoorFlip();
            }
        }
    }

    private void CabinetColliderFunction()
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

    private void CabinetDoorFlip()
    {
        Vector3 cabinetDoorFlip = cabinetDoor.transform.eulerAngles;        

        if(!isDoorOpen)
        {
            cabinetDoorFlip.y = 180;
            isDoorOpen = true;
            colliderFunctionActive = false;
            messageIndicatorGO.SetActive(false);
        }      

        cabinetDoor.transform.eulerAngles = cabinetDoorFlip;        
    }
}
