using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    // the counter where the kitchen object is placed
    private ClearCounter clearCounter;
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    // set and get the counter where the kitchen object is placed 
    public void SetClearCounter(ClearCounter clearCounter)
    {
/*        this.clearCounter = clearCounter;*/

        if (this.clearCounter != null) // the previous counter
        {
            // clear the kitchen object from the previous counter
            this.clearCounter.ClearKitchenObject();
        }
        this.clearCounter = clearCounter; //  which new counter the kitchen object will be placed

        if (clearCounter.HasKitchenObject()) // the new counter should not have a kitchen object
        {
            Debug.LogError("ClearCounter already has a KitchenObject!");
        }
        clearCounter.SetKitchenObject(this); // set the kitchen object on the new counter

        // The kitchen object's Transform component becomes the child of the clearCounter's Transform
        // component, and its relative location will now be adjusted based on the counterTopPoint
        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}
