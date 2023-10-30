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

    [Header("References")]
    [SerializeField] private TesticleManualController manualController;
    [SerializeField] private EnemyManager enemyManager;

    //Events- place in event manager, just for testing
    public event Action OnLevelComplete;

    //Local
    private EventManager eventManager;

    private int cancerCellsInLevel;
    private int numLumpsKilled;
    private int numCancerCellsKilled;

    private bool allLumpsKilled;
    private bool allCancerCellsKilled;
    private bool mainCancerCellKilled;
    private bool isLevelComplete;

    private void Start()
    {
        CurrentStage = LevelStage.Testicles;
        

        numLumpsKilled = 0;
        numCancerCellsKilled = 0;
        cancerCellsInLevel = enemyManager.GetNumCancerCells();
    }

    //
    private void OnEnable()
    {
        eventManager = EventManager.Instance;
        //Subscribe to events
        eventManager.OnLevelStart += HandleLevelStarting;
        eventManager.OnManualRead += HandleManualRead;
        eventManager.OnSceneChange += HandleSceneChange;
        //eventManager.OnCancerCellKilled += HandleCancerCellKilled;
        eventManager.OnLumpKilled += HandleLumpKilled;
        eventManager.OnMainCancerCellDetected += HandleMainCellDetected;
    }

    private void OnDisable()
    {
        //UnSubscribe to events
        eventManager.OnLevelStart -= HandleLevelStarting;
        eventManager.OnManualRead -= HandleManualRead;
        eventManager.OnSceneChange -= HandleSceneChange;
        //eventManager.OnCancerCellKilled -= HandleCancerCellKilled;
        eventManager.OnLumpKilled -= HandleLumpKilled;
        eventManager.OnMainCancerCellDetected -= HandleMainCellDetected;
    }

    //Events
    private void HandleMainCellDetected()
    {
        mainCancerCellKilled = true;
        enemyManager.SetCancerCellsActive();
        manualController.PromptPlayer("Eradicate all the cancer cells, using your cannon launcher", false);
        CheckIfLevelDone();
    }

    private void HandleLumpKilled()
    {
        //Check how many lumps left
        numLumpsKilled++;
        Debug.Log("Lump Killed");

        if(numLumpsKilled >= cancerCellsInLevel)
        {
            allLumpsKilled = true;
            CheckIfLevelDone();
        }
    }

    //private void HandleCancerCellKilled()
    //{
    //    //Check how many cancer cells left
    //    numCancerCellsKilled++;

    //    if(numCancerCellsKilled >= levelSettings[LevelNum].numCancerCells)
    //    {
    //        allCancerCellsKilled = true;
    //        CheckIfLevelDone();
    //    }
    //}

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
        manualController.PromptPlayer("Find the red cancer cell", false);
    }

    private void HandleLevelStarting()
    {
        //Prompt player to look and manual
        manualController.PromptPlayer("Look at the manual to identify the testicle cancer", true);
    }

    //Methods

    private void CheckIfLevelDone()
    {
        if(CurrentStage == LevelStage.Testicles)
        {
            if(allLumpsKilled)
            {
                isLevelComplete = true;
                manualController.PromptPlayer("Go to start area", false);
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
