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

    private EventManager eventManager;

    private void Start()
    {
        CurrentStage = LevelStage.Testicles;
        eventManager = EventManager.Instance;
    }

    //
    private void OnEnable()
    {
        //Subscribe to events
        eventManager.OnLevelStart += HandleLevelStarting;
        eventManager.OnManualRead += HandleManualRead;
        eventManager.OnSceneChange += HandleSceneChange;
        eventManager.OnCancerCellKilled += HandleCancerCellKilled;
        eventManager.OnLumpKilled += HandleLumpKilled;
        eventManager.OnMainCancerCellDetected += HandleMainCellKilled;
    }

    private void OnDisable()
    {
        //UnSubscribe to events
        eventManager.OnLevelStart -= HandleLevelStarting;
        eventManager.OnManualRead -= HandleManualRead;
        eventManager.OnSceneChange -= HandleSceneChange;
        eventManager.OnCancerCellKilled -= HandleCancerCellKilled;
        eventManager.OnLumpKilled -= HandleLumpKilled;
        eventManager.OnMainCancerCellDetected -= HandleMainCellKilled;
    }

    //Events
    private void HandleMainCellKilled()
    {
        //Prompt the player to go to next scene
    }

    private void HandleLumpKilled()
    {
        //Check how many lumps left
    }

    private void HandleCancerCellKilled()
    {
        //Check how many cancer cells left
    }

    private void HandleSceneChange()
    {
        //Load next scene
    }

    private void HandleManualRead()
    {
        //prompt player to find enemies
    }

    private void HandleLevelStarting()
    {
        //Prompt player to look and manual
    }


    public void ChangeStage(LevelStage stage)
    {
        CurrentStage = stage;
    }
}
