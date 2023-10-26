using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager instance;

    [SerializeField] private AudioSource acquireItem;
    [SerializeField] private AudioSource dropItem;
    [SerializeField] private AudioSource doorOpen;
    [SerializeField] private AudioSource doorCabinetOpen;

    private void Awake()
    {
        instance = this;
    }

    public void AcquireItemSound()
    {
        acquireItem.Play();
    }

    public void DropItemSound()
    {
        dropItem.Play();
    }

    public void DoorOpen()
    {
        doorOpen.Play();
    }

    public void DoorCabinetOpen()
    {
        doorCabinetOpen.Play();
    }

}
