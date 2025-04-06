using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrderlistUI : MonoBehaviour
{
    [SerializeField] private Transform recipeParent;
    [SerializeField] private RecipeUI recipeUITemplate;

    private void Start()
    {
        recipeUITemplate.gameObject.SetActive(false);
        OrderMananger.Instance.OnRecipeSpawned += Ordermanager_OnRecipeSpawned;
        OrderMananger.Instance.OnRecipeSuccessed += OrderManager_OnRecipeSuccessed;
    }

    private void OrderManager_OnRecipeSuccessed(object sender, System.EventArgs e)
    {
        UpdateUI();
    }
    private void Ordermanager_OnRecipeSpawned(object sender, System.EventArgs e)
    {
        UpdateUI();
    }

   

    private void UpdateUI()
    {
        foreach (Transform child in recipeParent)
        {
            if (child != recipeUITemplate.transform)
            {
                Destroy(child.gameObject);
            }
        }
        List<RecipeSO> recipeSOlist = OrderMananger.Instance.GetOrderlist();
        foreach (RecipeSO recipeSO in recipeSOlist)
        {
            RecipeUI recipeUI = GameObject.Instantiate(recipeUITemplate);
            recipeUI.transform.SetParent(recipeParent);
            recipeUI.gameObject.SetActive(true);
            recipeUI.UpdateUI(recipeSO);
        }
    }


}
