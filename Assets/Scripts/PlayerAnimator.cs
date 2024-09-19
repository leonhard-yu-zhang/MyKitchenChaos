using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    [SerializeField] private Player player;
    private Animator animator;
    private void Awake()
    {
        // Option 1: make a serialized field and drag the reference in the Unity editor
        // Option 2: since the animator is attached to the same game object, get component 
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
