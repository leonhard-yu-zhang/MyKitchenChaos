using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClearCounter : BaseCounter, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject()) // no kitchen object on the counter
        {
            if (player.HasKitchenObject()) // a kitchen object on the player's hand
            {
                // place the kitchen object on the counter
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else { }
        }
        else // a kitchen object on the counter
        {
            if (player.HasKitchenObject()) { }
            else // no kitchen object on the player's hand
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
