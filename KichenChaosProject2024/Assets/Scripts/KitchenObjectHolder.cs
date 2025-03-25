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
            Debug.LogWarning("Դ�������ϲ�����ʳ��,ת��ʧ�ܡ�");
            return;
        }
        if (targetCounter.GetKitchenObject() != null)
        {
            Debug.LogWarning("Ŀ��������ϴ���ʳ��,ת��ʧ�ܡ�");
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
