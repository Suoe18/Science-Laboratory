using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GogglesScript : MonoBehaviour
{
    public static GogglesScript instance;

    private Collider[] interactionCollider;
    [SerializeField] private float interactionRadius;
    [SerializeField] private GameObject messageIndicatorGO;
    [SerializeField] private GameObject gogglesGO;

    private bool canInteract;
    public float hasGoggles = 0;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        GogglesColliderFunction();

        if (canInteract)
        {
            if (hasGoggles < 1 && Input.GetKey(KeyCode.E))
            {
                Destroy(gogglesGO);
                InventoryManager.instance.AddItem(1);
                SoundEffectManager.instance.AcquireItemSound();
                hasGoggles = 1;
            }
        }
    }

    private void GogglesColliderFunction()
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
