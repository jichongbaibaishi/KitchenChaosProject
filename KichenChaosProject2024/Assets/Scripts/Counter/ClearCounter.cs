using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    /* [SerializeField] private ClearCounter transferTargetCounter;
     [SerializeField] private bool testing = false;



     private void Update()
     {
         if (testing && Input.GetMouseButtonDown(0))
         {
             TransferKitchenObject(this, transferTargetCounter);
         }
     }
    */
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
