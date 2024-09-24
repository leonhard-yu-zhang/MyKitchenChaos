using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    // // the counter where the kitchen object is placed
    // private ClearCounter clearCounter;

    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

/*    // set and get the counter where the kitchen object is placed 
    public void SetClearCounter(ClearCounter clearCounter)
    {
*//*        this.clearCounter = clearCounter;*//*

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
    }*/

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        // decouple the kitchen object from the old kitchen object parent
        // couple it with the new kitchen object parent
        if(this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent = kitchenObjectParent;

        if (kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("already has a KitchenObject as child");
        }
        kitchenObjectParent.SetKitchenObject(this);

        // parent-child relationship between Transform components
        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }

    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObject(); // kitchenObjectParent.kitchenObject = null
        Destroy(gameObject);
    }

    public static KitchenObject SpawnKitchenObject(KitchenObjectSO kitchenObjectSO, IKitchenObjectParent kitchenObjectParent)
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);
        return kitchenObject;

    }
}
