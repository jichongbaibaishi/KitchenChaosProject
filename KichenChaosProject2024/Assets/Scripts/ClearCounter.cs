using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField]private GameObject selectedCounter;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform topPoint;
    public void Interact()
    {
        GameObject go= GameObject.Instantiate(kitchenObjectSO.prefab, topPoint);
        go.transform.localPosition = Vector3.zero;
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
