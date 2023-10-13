using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesticleManualController : MonoBehaviour
{
    public GameObject manualScreen1;
    public GameObject manualScreen2;
    public GameObject manualScreen3;
    public GameObject manualScreen4;
    public static bool manualActive;

    public void Start()
    {
        manualActive = false;
    }

    public void OnManualButtonClick()
    {
        Time.timeScale = 0f;
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
        manualScreen4.SetActive(false);
        manualActive = false;
        Time.timeScale = 1f;
    }

    public void OnBackManual4Click()
    {
        manualScreen4.SetActive(false);
        manualScreen3.SetActive(true);
    }

    
}
