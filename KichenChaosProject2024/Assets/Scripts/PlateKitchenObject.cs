using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField]private List<KitchenObjectSO> validKitchenObjectSOlist;

    [SerializeField] private PlateCompleteVisual plateCompleteVisual;

    [SerializeField] private KitchenObjectGridUI kitchenObjectGridUI;

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
        plateCompleteVisual.ShowKitchenObject(kitchenObjectSO);
        kitchenObjectGridUI.ShowKitchenObjectUI(kitchenObjectSO);
        kitchenObjectSOlist.Add(kitchenObjectSO);
        return true;
    }
    public List<KitchenObjectSO> GetKitchenObjectSOlist()
    {
        return kitchenObjectSOlist;
    }
}
