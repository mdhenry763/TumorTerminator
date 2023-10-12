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

    [Header("Weapon Aiming Settings:")]
    [SerializeField] private Transform weaponTransform; // The transform of your weapon
    [SerializeField] private Camera mainCamera; // Your main camera (usually the player's camera)

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
        AimWeaponAtCursor();
        HandlePlayerLook();
    }

    private void HandlePlayerLookInput(Vector2 lookInput)
    {
        Debug.Log("Look Input");
        previousLookInput = new Vector3(lookInput.x, 0, lookInput.y);
    }

    void AimWeaponAtCursor()
    {
        // Create a ray from the camera through the cursor's position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Determine the direction to aim the weapon
            Vector3 aimDirection = hit.point - weaponTransform.position;
            aimDirection.y = 0;
            aimDirection.z = 0;
            weaponTransform.forward = aimDirection;
        }
    }

    private void HandlePlayerLook()
    {
        crosshairTransform.anchoredPosition += new Vector2(0, previousLookInput.z * crosshairSpeed * Time.deltaTime);
    }
   
}
