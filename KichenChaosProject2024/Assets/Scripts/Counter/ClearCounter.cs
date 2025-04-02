using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {//手上有食材
            if (player.GetKitchenObject().TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plateKitchenObject))
            {
                //有盘子
                if (IsHaveKitchenObject() == false)
                {//当前柜台为空
                    TransferKitchenObject(player, this);
                }
                else
                {//当前柜台不为空
                    bool isSuccess=plateKitchenObject.AddKitchenObject(GetKitchenObjectSO());
                    if (isSuccess)
                    {
                        DestroyKitchenObject();
                    }
                    
                }
            }
            else
            {   //没盘子
                if (IsHaveKitchenObject() == false)
                {//当前柜台为空
                    TransferKitchenObject(player, this);
                }
                else
                {//当前柜台不为空
                    if(GetKitchenObject().TryGetComponent<PlateKitchenObject>(out plateKitchenObject))
                    {
                        bool isSuccess = plateKitchenObject.AddKitchenObject(player.GetKitchenObjectSO());
                        if (isSuccess)
                        {
                            player.DestroyKitchenObject();
                        }
                    }
                }

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
}
