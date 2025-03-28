using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;
    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {//手上有食材
            if (IsHaveKitchenObject() == false)
            {//当前柜台为空
                TransferKitchenObject(player, this);
            }
            else
            {//当前柜台不为空

            }
        }
        else
        {//手上没食材
            if (IsHaveKitchenObject() == false)
            {//当前柜台为空

            }
            else
            {//当前柜台不为空
                TransferKitchenObject(this, player);
            }
        }
    }
    public override void InteractOperate(Player player)
    {
        if (IsHaveKitchenObject()==true) {
            DestroyKitchenObject();
            CreateKitchenObject(cutKitchenObjectSO.prefab);
        }
    }
}
