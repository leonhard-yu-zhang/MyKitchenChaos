using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    // subscriber
    private const string CUT = "Cut";
    [SerializeField] private CuttingCounter cuttingCounter;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        cuttingCounter.OnCut += CuttingCounter_OnCut;
    }

    private void CuttingCounter_OnCut(object sender, EventArgs e)
    {
        /* when you call SetTrigger(OPEN_CLOSE), it sets the trigger to true, causing
        a transition to thr assiciated animation (close->open). The trigger is 
        automatically reset to false by Unity after the transition*/
        animator.SetTrigger(CUT);
    }
}
