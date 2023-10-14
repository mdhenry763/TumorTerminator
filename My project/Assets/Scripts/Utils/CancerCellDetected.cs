using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerCellDetected : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Main Cell Detected");
            EventManager.Instance.MainCancerCellDetectedEvent();
        }
    }
}
