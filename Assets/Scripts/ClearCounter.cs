using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    // [SerializeField] private Transform tomatoPrefab;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    // the kitchen object on the current counter
    private KitchenObject kitchenObject;

    private void Update()
    {
        // When the T key is pressed, set the parent of the kitchen object on the current counter
        // to another counter in order to move its position
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if(kitchenObject != null)
            {
                // kitchenObject.SetClearCounter(secondClearCounter);
                kitchenObject.SetKitchenObjectParent(secondClearCounter);
            }
        }
    }
    public void Interact()
    {
        if (kitchenObject == null) // generate a kitchen object if there is no one
        {
            // Debug.Log("Interact");
            // Transform tomatoTransform = Instantiate(tomatoPrefab, counterTopPoint);
            // tomatoTransform.localPosition = Vector3.zero; // not the global position
            
            // e.g. instantiate a tomato prefab
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            /*            kitchenObjectTranform.localPosition = Vector3.zero;
                        *//*            Debug.Log(kitchenObjectTranform.GetComponent<KitchenObject>().
                                        GetKitchenObjectSO().objectName);*//*
                        kitchenObject = kitchenObjectTranform.GetComponent<KitchenObject>();
                        kitchenObject.SetClearCounter(this);*/
            // kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            // Debug.Log(kitchenObject.GetClearCounter());
            Debug.Log(kitchenObject.GetKitchenObjectParent());
            // when interacting, give the kitchen object on the counter to the player
        }

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
