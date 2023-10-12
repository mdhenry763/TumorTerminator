using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(fileName = "New Input Reader", menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    private Controls controls;

    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;

    bool move;

    private void OnEnable()
    {
        if(controls == null) 
        {
            controls = new Controls();
            controls.Player.AddCallbacks(this);
        }
        
        controls.Player.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            move = true;
            
        }

        if(context.canceled)
        {
            move= false;
        }

        OnMoveEvent?.Invoke(context.ReadValue<Vector2>());

    }

    public void OnFire(InputAction.CallbackContext context)
    {
        
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if(!move)
        {
            OnLookEvent?.Invoke(context.ReadValue<Vector2>());
        }
        
    }
}
