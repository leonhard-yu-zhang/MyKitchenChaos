using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    // [SerializeField] private Transform tomatoPrefab;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    public void Interact()
    {
        Debug.Log("Interact");
        // Transform tomatoTransform = Instantiate(tomatoPrefab, counterTopPoint);
        // tomatoTransform.localPosition = Vector3.zero; // not the global position
        Transform kitchenObjectTranform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
        kitchenObjectTranform.localPosition = Vector3.zero;

        Debug.Log(kitchenObjectTranform.GetComponent<KitchenObject>().
            GetKitchenObjectSO().objectName);
    }

}
