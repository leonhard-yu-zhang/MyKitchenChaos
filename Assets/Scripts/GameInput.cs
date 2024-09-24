using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        // there exists an event: public event Action<CallbackContext> performed
        // delegate void Action<CallbackContext>(CallbackContext obj) returns void

        /* playerInputActions.Player.Interact serves as the publisher for the performed event
         * the Interact_performed method is added to the performed event.
         * When the Interact action is triggered (e.g., when the corresponding 
         * button is pressed), the Interact_performed method will be called.
         */
        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
    }

    /* When one triggers event performed to perform the Interact action (by pressing the assigned key/button), 
     * the Interact_performed method is called.
     * Inside Interact_performed, the OnInteractAction event is raised, notifying any 
     * subscribers that the interaction has occurred.
     */
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
/*        // another option
        if (OnInteractAction != null) // there exist subscribers
        {
            OnInteractAction(this, EventArgs.Empty);
        }*/
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
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
