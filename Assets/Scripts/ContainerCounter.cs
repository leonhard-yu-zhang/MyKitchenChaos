using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter, IKitchenObjectParent
{
    public event EventHandler OnPlayerGrabbedObject;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    // public void Interact(Player player)
    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject()) // the player doesn't hold any kitchen object
        {
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
           /* Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);*/
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
