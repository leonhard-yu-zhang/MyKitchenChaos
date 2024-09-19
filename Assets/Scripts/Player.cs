using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // [SerializeField]: serialize private fields, making them visible and
    // editable in the Unity Inspector (Editor) window
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayewrMask;

    private bool isWalking;
    private Vector3 lastInteractDir;

    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y).normalized;

        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }
        float interactDistance = 2f;
        if(Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHit, interactDistance, countersLayewrMask))
        {
            if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                //Has ClearCounter
                clearCounter.Interact();

            }
            Debug.Log(raycastHit.transform);
        }
        else
        {
            Debug.Log("-");
        }
    }
    private void HandleMovement()
    {
        /*        // refactor, this part is moved to the class GameInput in GameInput.cs
        Vector2 inputVector = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
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
        }
        inputVector = inputVector.normalized;*/

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        // 3D move direction
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y).normalized;

        /*        // deltaTime: the number of seconds elapse since the last frame
                // make sure the movement unrelated to FPS
                transform.position += moveDir*Time.deltaTime*moveSpeed;*/

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        /*        // can't move if the raycast hits something. issue: if the (infinitely thin) raycast being fired from the center of the player doesn't hit the box
                // the player can still go through the box, the collison detection fails
                bool canMove = !Physics.Raycast(transform.position, moveDir, playerRadius);
                if (canMove)
                {
                    transform.position += moveDir * Time.deltaTime * moveSpeed;
                }*/
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);
        // solve the problem while moving diagonally
        if (!canMove)
        {
            // cannot move torwards moveDir. Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position +
                Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            if (canMove)
            {
                // can move only on the X
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove)
                {
                    // can move only on the Z
                    moveDir = moveDirZ;
                }
                else
                {
                    // cannot move in X and Z directions
                }
            }
        }
        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }

        float rotateSpeed = 50f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

        // walking when move direction is not zero
        isWalking = moveDir != Vector3.zero;
    }
}
