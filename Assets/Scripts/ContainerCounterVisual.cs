using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    // subscriber
    private const string OPEN_CLOSE = "OpenClose";
    [SerializeField] private ContainerCounter containerCounter;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        containerCounter.OnPlayerGrabbedObject += ContainerCounter_OnPlayerGrabbedObject;
    }

    private void ContainerCounter_OnPlayerGrabbedObject(object sender, EventArgs e)
    {
        /* when you call SetTrigger(OPEN_CLOSE), it sets the trigger to true, causing
        a transition to thr assiciated animation (close->open). The trigger is 
        automatically reset to false by Unity after the transition*/
        animator.SetTrigger(OPEN_CLOSE);
    }
}
