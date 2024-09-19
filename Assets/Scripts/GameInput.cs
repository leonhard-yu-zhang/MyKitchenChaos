using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        // there exists public event Action<CallbackContext> performed
        // delegate void Action<CallbackContext>(CallbackContext obj) returns void
        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
/*        // another option
        if (OnInteractAction != null) // there exist subscribers
        {
            OnInteractAction(this, EventArgs.Empty);
        }*/
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
/*        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }*/
        inputVector = inputVector.normalized;
        Debug.Log(inputVector);
        return inputVector;
    }
}
