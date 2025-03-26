using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//冰箱柜台
public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    public override void Interact(Player player)
    {
        if (GetKitchenObject() == null)
        {
            KitchenObject kitchenObject = GameObject.Instantiate(kitchenObjectSO.prefab, GetHoldPoint()).GetComponent<KitchenObject>();
            SetKitchenObject(kitchenObject);
        }
        else
        {
            TransferKitchenObject(this, player);
        }
    }
}


