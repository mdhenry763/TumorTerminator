using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Scene Start");
            EventManager.Instance.LevelStartEvent();
            gameObject.SetActive(false);
        }
    }
}
