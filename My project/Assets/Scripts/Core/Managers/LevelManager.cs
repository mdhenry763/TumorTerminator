using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelStage
{
    Testicles,
    Lung,
    Throat
}


public class LevelManager : MonoBehaviour
{
    public LevelStage CurrentStage { get; private set; }

    private void Start()
    {
        CurrentStage = LevelStage.Testicles;
    }

    //
    private void OnEnable()
    {
        //Subscribe to events
    }

    private void OnDisable()
    {
        //UnSubscribe to events
    }

    public void ChangeStage(LevelStage stage)
    {
        CurrentStage = stage;
    }
}
