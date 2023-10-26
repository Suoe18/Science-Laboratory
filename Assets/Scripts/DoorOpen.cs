using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;

    [SerializeField] private float slideSpeed;
    [SerializeField] private Vector3 leftDoorTargetPos;
    [SerializeField] private Vector3 rightDoorTargetPos;

    private Vector3 leftDoorInitialPos;
    private Vector3 rightDoorInitialPos;

    private bool isDoorOpen;

    private void Start()
    {
        leftDoorInitialPos = leftDoor.transform.position;
        rightDoorInitialPos = rightDoor.transform.position;
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (!isDoorOpen)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(SlideLeftDoorCoroutine(leftDoorInitialPos, leftDoorTargetPos));
                StartCoroutine(SlideRightDoorCoroutine(rightDoorInitialPos, rightDoorTargetPos));
                SoundEffectManager.instance.DoorOpen();
                isDoorOpen = true;
            }            
        }                
    }

    private void OnTriggerExit(Collider other)
    {
        if (isDoorOpen)
        {
            StartCoroutine(CloseDoor());
        }
    }


    private IEnumerator SlideLeftDoorCoroutine(Vector3 start, Vector3 end)
    {
        float elapsedTime = 0f;

        while (elapsedTime < slideSpeed)
        {
            leftDoor.transform.position = Vector3.Lerp(start, end, elapsedTime / slideSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        leftDoor.transform.position = end;
    }

    private IEnumerator SlideRightDoorCoroutine(Vector3 start, Vector3 end)
    {
        float elapsedTime = 0f;

        while (elapsedTime < slideSpeed)
        {
            rightDoor.transform.position = Vector3.Lerp(start, end, elapsedTime / slideSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rightDoor.transform.position = end;
    }

    private IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(1);
        SoundEffectManager.instance.DoorOpen();
        StartCoroutine(SlideLeftDoorCoroutine(leftDoorTargetPos, leftDoorInitialPos));
        StartCoroutine(SlideRightDoorCoroutine(rightDoorTargetPos, rightDoorInitialPos));        
        isDoorOpen = false;
    }
}
