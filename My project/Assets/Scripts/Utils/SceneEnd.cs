using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEnd : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] Collider col;

    private void Start()
    {
        col.enabled = false;
    }

    private void OnEnable()
    {
        levelManager.OnLevelComplete += HandleLevelComplete;
    }


    private void OnDisable()
    {
        levelManager.OnLevelComplete -= HandleLevelComplete;
    }

    private void HandleLevelComplete()
    {
        col.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(col.enabled)
        {
            if(other.CompareTag("Player"))
            {
                LevelLoader.Instance.LoadLevel(SceneNames.IntroScene);
            }

        }
    }

}
