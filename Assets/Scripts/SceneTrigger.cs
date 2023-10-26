using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject camSceneBrain;
    [SerializeField] private GameObject firstScene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            camSceneBrain.SetActive(true);
            firstScene.SetActive(true);
            Destroy(this, 1);
        }
    }
}
