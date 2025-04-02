using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField]private List<KitchenObjectSO> validKitchenObjectSOlist;
    private List<KitchenObjectSO> kitchenObjectSOlist = new List<KitchenObjectSO>();
   public bool AddKitchenObject(KitchenObjectSO kitchenObjectSO)
    {
        if (kitchenObjectSOlist.Contains(kitchenObjectSO))
        {
            return false;
        }
        if (validKitchenObjectSOlist.Contains(kitchenObjectSO)==false)
        {
            return false;
        }
        kitchenObjectSOlist.Add(kitchenObjectSO);
        return true;
    }
}
