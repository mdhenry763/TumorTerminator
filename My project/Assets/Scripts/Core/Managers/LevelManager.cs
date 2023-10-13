using System;
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
    public int LevelNum { get; private set; }

    [Header("Level Managemenet")]
    [SerializeField] private LevelSO[] levelSettings;

    //Events
    public event Action OnLevelComplete;

    //Local
    private EventManager eventManager;

    private int numLumpsKilled;
    private int numCancerCellsKilled;

    private bool allLumpsKilled;
    private bool allCancerCellsKilled;
    private bool mainCancerCellKilled;
    private bool isLevelComplete;

    private void Start()
    {
        CurrentStage = LevelStage.Testicles;
        eventManager = EventManager.Instance;

        numLumpsKilled = 0;
        numCancerCellsKilled = 0;
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
        mainCancerCellKilled = true;
        CheckIfLevelDone();
    }

    private void HandleLumpKilled()
    {
        //Check how many lumps left
        numLumpsKilled++;

        if(numLumpsKilled >= levelSettings[LevelNum].numLumps)
        {
            allLumpsKilled = true;
            CheckIfLevelDone();
        }
    }

    private void HandleCancerCellKilled()
    {
        //Check how many cancer cells left
        numCancerCellsKilled++;

        if(numCancerCellsKilled >= levelSettings[LevelNum].numCancerCells)
        {
            allCancerCellsKilled = true;
            CheckIfLevelDone();
        }
    }

    private void HandleSceneChange()
    {
        //Load next scene
        if(isLevelComplete)
        {
            LevelNum++;
            LevelStage stage = (LevelStage)LevelNum;
            ChangeStage(stage);
            ResetLevel();
        }
        
    }

    private void HandleManualRead()
    {
        //prompt player to find enemies
    }

    private void HandleLevelStarting()
    {
        //Prompt player to look and manual
    }

    //Methods

    private void CheckIfLevelDone()
    {
        if(CurrentStage == LevelStage.Testicles)
        {
            if(allCancerCellsKilled && allLumpsKilled && mainCancerCellKilled)
            {
                isLevelComplete = true;
                OnLevelComplete?.Invoke();
            }
        }
    }

    private void ResetLevel()
    {
        allCancerCellsKilled = false;
        allLumpsKilled = false;
        mainCancerCellKilled = false;
        isLevelComplete = false;
    }


    private void ChangeStage(LevelStage stage)
    {
        CurrentStage = stage;
    }
}
