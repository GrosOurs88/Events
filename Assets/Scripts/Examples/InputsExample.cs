using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsExample : MonoBehaviour
{
    private PlayerInput playerInput = null;
    public InputActionReference moveReference = null;
    public InputActionReference lookReference = null;

    private Vector3 movement = Vector3.zero;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerInput.onActionTriggered += OnMoveActionTriggered;
        playerInput.onActionTriggered += OnLookActionTriggered;
    }

    private void OnDisable()
    {
        playerInput.onActionTriggered -= OnMoveActionTriggered;
        playerInput.onActionTriggered -= OnLookActionTriggered;
    }

    private void OnMoveActionTriggered( InputAction.CallbackContext callbackContext )
    {
        if (callbackContext.action == moveReference.action)
        {
            Vector3 movement = new Vector3(moveReference.action.ReadValue<Vector2>().x,
                                           0.0f,
                                           moveReference.action.ReadValue<Vector2>().y);
            transform.Translate(movement);

            //Debug.Log( $"move {callbackContext.phase}" );
        }
    }

    private void OnLookActionTriggered( InputAction.CallbackContext callbackContext )
    {
        if (callbackContext.action == lookReference.action)
        {


            //Debug.Log($"mlook {callbackContext.phase}");
        }
    }

    private void Update()
    {
        
    }
}
