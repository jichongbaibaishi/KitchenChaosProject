using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : KitchenObjectHolder
{
    [SerializeField] private GameObject selectedCounter;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
  
    [SerializeField] private ClearCounter transferTargetCounter;
    [SerializeField] private bool testing = false;

    

    private void Update()
    {
        if (testing && Input.GetMouseButtonDown(0))
        {
            TransferKitchenObject(this, transferTargetCounter);
        }
    }

    public void Interact()
    { 
       
        if (GetComponent<KitchenObject>() == null) {
            KitchenObject kitchenObject = GameObject.Instantiate(kitchenObjectSO.prefab, GetHoldPoint()).GetComponent<KitchenObject>();
            SetKitchenObject(kitchenObject);
        }
        else
        {
            Debug.LogWarning("已经有了" + gameObject);
        }
        
    }
    public void SelectCounter()
    {
        selectedCounter.SetActive(true);
    }
    public void CancelSelect()
    {
        selectedCounter.SetActive(false);
    }
    
   
}
