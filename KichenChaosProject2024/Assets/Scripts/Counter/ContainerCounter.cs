using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//冰箱柜台
public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    [SerializeField] private ContainerCounterVisual containCounterVisual;

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject()) return;
        CreateKitchenObject(kitchenObjectSO.prefab);
        TransferKitchenObject(this, player);
        containCounterVisual.PlayOpen();
    }
    public void CreateKitchenObject(GameObject kitchenObjectPrefab)
    {
        KitchenObject kitchenObject = GameObject.Instantiate(kitchenObjectPrefab, GetHoldPoint()).GetComponent<KitchenObject>();
        SetKitchenObject(kitchenObject);
    }
}


