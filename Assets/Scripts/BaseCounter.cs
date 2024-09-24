using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{   // protected: be accessible to this class and any class that extends it
    // virtual
    // or abstract?

    [SerializeField] private Transform counterTopPoint;
    private KitchenObject kitchenObject;
    public virtual void Interact(Player player)
    {
        Debug.LogError("BaseCounter.Interact()");
    }

    public virtual void InteractAlternate(Player player)
    {
        Debug.LogError("BaseCounter.InteractAlternate()");
    }
    public Transform GetKitchenObjectFollowTransform()
    {
        // The position where the kitchen object placed on the counter
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        // place a new kitchn object on the counter
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        // which kitchen object is on the counter
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        // remove the kitchen object on the counter
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        // whether there is a kitchen object on the counter
        return kitchenObject != null;
    }
}
