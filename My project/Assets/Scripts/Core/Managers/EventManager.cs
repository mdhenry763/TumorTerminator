using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public event Action OnLevelStart;
    public event Action OnManualRead;

    public event Action OnLumpKilled;
    public event Action OnMainCancerCellDetected;
    //This event for smaller cnacer cells
    public event Action OnCancerCellKilled;
    //This eventis for main cancer cell
    public event Action OnMainCancerCellKilled;
    //This will be called once the player has entered the new scene
    public event Action OnSceneChange;

    public void LevelStartEvent()
    {
        OnLevelStart?.Invoke();
    }

    public void ManualReadEvent()
    {
        OnManualRead?.Invoke();
    }

    public void MainCancerCellDetectedEvent()
    {
        OnMainCancerCellDetected?.Invoke();
    }

    public void MainCancerCellKilled()
    {
        OnMainCancerCellKilled?.Invoke();
    }

    public void SceneChangeEvent()
    {
        OnSceneChange?.Invoke();
    }

    public void LumpKilledEvent()
    {
        OnLumpKilled?.Invoke();
    }

}
