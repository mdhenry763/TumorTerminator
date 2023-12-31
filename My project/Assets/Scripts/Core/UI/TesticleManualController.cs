using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TesticleManualController : MonoBehaviour
{
    public GameObject manualScreen1;
    public GameObject manualScreen2;
    public GameObject manualScreen3;
    public GameObject manualScreen4;
    public static bool manualActive;

    [Header("Player Prompt")]
    [SerializeField] private GameObject promptScreen;
    [SerializeField] private TMP_Text promptText;

    public void Start()
    {
        manualActive = false;
    }

    public void OnManualButtonClick()
    {
        SetTimeScale(0);
        promptScreen.SetActive(false);
        manualScreen1.SetActive(true);
    }

    public void OnNextManual1Click()
    {
        manualScreen2.SetActive(true);
        manualScreen1.SetActive(false);
    }
    public void OnManualExitClick()
    {
        manualScreen1.SetActive(false);
    }
    
    public void OnNextManual2Click()
    {
        manualScreen3.SetActive(true);
        manualScreen2.SetActive(false);
    }
    public void OnBackManual2Click()
    {
        manualScreen2.SetActive(false);
        manualScreen1.SetActive(true);
    }
    
    public void OnNextManual3Click()
    {
        manualScreen4.SetActive(true);
        manualScreen3.SetActive(false);
    }
    public void OnBackManual3Click()
    {
        manualScreen3.SetActive(false);
        manualScreen2.SetActive(true);
    }

    public void OnDoneManualClick()
    {
        //manualScreen4.SetActive(false);
        //For testing @Dylan
        manualScreen1.SetActive(false) ;
        manualActive = false;
        EventManager.Instance.ManualReadEvent();
        SetTimeScale(1);
    }

    public void OnBackManual4Click()
    {
        manualScreen4.SetActive(false);
        manualScreen3.SetActive(true);
    }

    public void PromptPlayer(string propmt, bool pauseGame)
    {
        promptScreen.SetActive(true);
        promptText.text = propmt;
        if (pauseGame)
        {
            SetTimeScale(0);
        }
        else StartCoroutine(ShowItemFor(5, promptScreen));
        
    }

    private void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }

    IEnumerator ShowItemFor(float lifetime, GameObject obj)
    {
        yield return new WaitForSeconds(lifetime);
        obj.SetActive(false);

    }

}
