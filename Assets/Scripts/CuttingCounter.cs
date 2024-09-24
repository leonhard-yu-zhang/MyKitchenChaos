using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CuttingCounter : BaseCounter, IKitchenObjectParent
{
    // [SerializeField] private KitchenObjectSO cutKitchenObjectSO;
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;

    private int cuttingProgess;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject()) // no kitchen object on the cutting counter
        {
            if (player.HasKitchenObject()) // a kitchen object on the player's hand
            {
                // if the kitchen object can be cut into slices
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    // place the kitchen object on the cutting counter
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    cuttingProgess = 0;
                }
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

    public override void InteractAlternate(Player player)
    {
        // if there's a kitchen object on the cutting counter, and also need to check:
        // if the sliced kitchen object is still on the cutting counter, you can't cut it again
        if (HasKitchenObject()&&HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            // get the KitchenObjectSO scriptable object of this kitchen object
            // there are different recipes Tomato-TomatoSlices,... the cuttingRecipe SOArray
            // the input of recipe Tomato-TomatoSlices is Tomato (KitchenObjectSO)
            // if matches, return TomatoSlices (KitchenObjectSO)
            cuttingProgess ++;
            CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
            if (cuttingProgess >= cuttingRecipeSO.cuttingProgessMax)
            {
                KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
                GetKitchenObject().DestroySelf(); // destroy the kitchen object on the cutting counter
                KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);

                /*            Transform kitchenObjectTransform = Instantiate(cutKitchenObjectSO.prefab);
                            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);*/
                // KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
            }
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        /*        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
                {
                    if (cuttingRecipeSO.input == inputKitchenObjectSO)
                    {
                        return true;
                    }
                }
                return false;*/
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
        return cuttingRecipeSO != null;
    }
    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
/*        foreach(CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO.output;
            }
        }
        return null;*/
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
        if (cuttingRecipeSO != null)
        {
            return cuttingRecipeSO.output;
        }
        else
        {
            return null;
        }
 
    }

    private CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO;
            }
        }
        return null;
    }
}

