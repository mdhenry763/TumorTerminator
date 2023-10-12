using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References: ")]
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Rigidbody rb;

    [Header("Settings: ")]
    [SerializeField] float defaultMoveSpeed = 7f;
    [SerializeField] float defaultTurnRate = 180f;

    private Vector3 previousMovementInput;
    private Vector3 previousLookInput;
    private float currentMoveSpeed;

    bool moveInput;

    private void Start()
    {
        currentMoveSpeed = defaultMoveSpeed;
    }

    private void OnEnable()
    {
        inputReader.OnMoveEvent += HandlePlayerMoveInput;
        inputReader.OnLookEvent += HandlePlayerLookInput;
    }

    private void OnDisable()
    {
        inputReader.OnMoveEvent -= HandlePlayerMoveInput;
        inputReader.OnLookEvent -= HandlePlayerLookInput;
    }

    private void Update()
    {
        HandlePlayerMove();
        HandlePlayerLook();

        Vector3 playerPos = transform.position;
        playerPos.y = 0;
        transform.position = playerPos;

    }

    //Subscription to OnMoveEvent
    private void HandlePlayerMoveInput(Vector2 moveInput)
    {
        Debug.Log("Move Input");
        previousMovementInput = new Vector3(moveInput.x, 0, moveInput.y);

    }

    private void HandlePlayerLookInput(Vector2 lookInput)
    {
        Debug.Log("Look Input");
        previousLookInput = new Vector3(lookInput.x, 0, lookInput.y);
    }


    private void HandlePlayerMove()
    {
        //Move player based on previous movement input
        // rb.velocity = previousMovementInput * currentMoveSpeed;

        //If there is move input then rotate player
        Vector3 moveDirection = transform.TransformDirection(previousMovementInput);
        transform.position += moveDirection * currentMoveSpeed * Time.deltaTime;
    }

    private void HandlePlayerLook()
    {
        if (moveInput) return;

        //Left and right rotation
        Vector3 yRotation = new Vector3(0, previousLookInput.x, 0);
        Vector3 xRotation = new Vector3(previousLookInput.y, 0, 0);

        if(previousLookInput.sqrMagnitude > 0) 
        {
            transform.Rotate(yRotation * 2);
        }
        
    }
}
