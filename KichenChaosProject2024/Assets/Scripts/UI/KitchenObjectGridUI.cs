using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class KitchenObjectGridUI : MonoBehaviour
{
    [SerializeField] private KitchenObjectIconUI iconTemplateUI;

    private void Start()
    {
        iconTemplateUI.gameObject.SetActive(false);
    }

    public void ShowKitchenObjectUI(KitchenObjectSO kitchenObjectSO)
    {
        KitchenObjectIconUI newIconUI = GameObject.Instantiate(iconTemplateUI, transform);
        newIconUI.Show(kitchenObjectSO.sprite);
    }
}
