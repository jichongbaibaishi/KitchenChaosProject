using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {//������ʳ��
            if (IsHaveKitchenObject() == false)
            {//��ǰ��̨Ϊ��
                TransferKitchenObject(player, this);
            }
            else
            {//��ǰ��̨��Ϊ��

            }
        }
        else
        {//����ûʳ��
            if (IsHaveKitchenObject() == false)
            {//��ǰ��̨Ϊ��
                
            }
            else
            {//��ǰ��̨��Ϊ��
                TransferKitchenObject(this, player);
            }
        }
    }
   
}
