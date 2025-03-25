using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectHolder : MonoBehaviour
{
    
    [SerializeField] private Transform holdPoint;

    private KitchenObject kitchenObject;

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        kitchenObject.transform.localPosition = Vector3.zero;

    }
    public Transform GetHoldPoint()
    {
        return holdPoint;
    }

    public void TransferKitchenObject(ClearCounter sourceCounter,ClearCounter targetCounter)
    {
        if (sourceCounter.GetKitchenObject() == null)
        {
            Debug.LogWarning("源持有者上不存在食材,转移失败。");
            return;
        }
        if (targetCounter.GetKitchenObject() != null)
        {
            Debug.LogWarning("目标持有者上存在食材,转移失败。");
            return;
        }
        targetCounter.AddKitchenObject(sourceCounter.GetKitchenObject());
        sourceCounter.ClearKitchenObject();
    }
    public void AddKitchenObject(KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(holdPoint);
        SetKitchenObject(kitchenObject);
    }

    public void ClearKitchenObject()
    {
        this.kitchenObject = null;
    }
}
