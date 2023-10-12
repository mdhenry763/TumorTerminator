using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Rendering.FilterWindow;
using static UnityEngine.Rendering.DebugUI.Table;

public class PlayerAiming : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputReader inputReader;

    [Header("Crosshair Settings:")]
    [SerializeField] private RectTransform crosshairTransform; 
    [SerializeField] private float crosshairSpeed = 50f;

    private Vector3 previousLookInput;

    private void OnEnable()
    {
        inputReader.OnLookEvent += HandlePlayerLookInput;
    }

    private void OnDisable()
    {
        inputReader.OnLookEvent -= HandlePlayerLookInput;
    }

    private void Update()
    {
        HandlePlayerLook();
    }

    private void HandlePlayerLookInput(Vector2 lookInput)
    {
        Debug.Log("Look Input");
        previousLookInput = new Vector3(lookInput.x, 0, lookInput.y);
    }

    private void HandlePlayerLook()
    {
        crosshairTransform.anchoredPosition += new Vector2(0, previousLookInput.z * crosshairSpeed * Time.deltaTime);
    }
   
}
