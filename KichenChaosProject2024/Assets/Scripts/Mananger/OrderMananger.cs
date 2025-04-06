using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderMananger : MonoBehaviour
{
    public static OrderMananger Instance { get; private set; }
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeSuccessed;
    public event EventHandler OnRecipeFailed;
    [SerializeField] private RecipelistSO recipeSOlist;
    [SerializeField] private int orderMaxCount = 5;
    [SerializeField] private float orderRate = 2;
    private List<RecipeSO> orderRecipeSOlist = new List<RecipeSO>();

    private float orderTimer = 0;
    private int orderCount = 0;
    private bool isStart = false;

    private void Awake(){
        Instance = this;
    }
    private void Start()
    {
        isStart = true;
    }
    private void Update()
    {
        if (isStart) {
            OrderUpdate();
        
        }
    }
    private void OrderUpdate()
    {
        orderTimer += Time.deltaTime;
        if (orderTimer >= orderRate)
        {
            orderTimer = 0;
            OrderAnewRecipe();

        }
    }

    private void OrderAnewRecipe()
    {
        if (orderCount>=orderMaxCount) {
            return;
        }
        orderCount++;
        int index = UnityEngine.Random.Range(0, recipeSOlist.recipeSOlists.Count);
        orderRecipeSOlist.Add(recipeSOlist.recipeSOlists[index]);
        OnRecipeSpawned?.Invoke(this,EventArgs.Empty);
    }
    public void Delivery(PlateKitchenObject plateKitchenObject)
    {
        RecipeSO correctRecipe = null;
        foreach (RecipeSO recipe in orderRecipeSOlist) {
            if(IsCorrect(recipe, plateKitchenObject))
            {
                correctRecipe = recipe;
                break;
            }
        }
        if (correctRecipe == null)
        {
            print("上菜失败");
            OnRecipeFailed?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            orderRecipeSOlist.Remove(correctRecipe
                );
            OnRecipeSuccessed?.Invoke(this, EventArgs.Empty);
            print("上菜成功");
        }
    }
    private bool IsCorrect(RecipeSO recipeSO, PlateKitchenObject plateKitchenObject) {

        List<KitchenObjectSO> s1=recipeSO.kitchenObjectSOs;
        List<KitchenObjectSO> s2=plateKitchenObject.GetKitchenObjectSOlist();
        if (s1.Count != s2.Count)
        {
            return false;
        }
        
        
        foreach(KitchenObjectSO kitchenObjectSO in s1)
        {
                if (s2.Contains(kitchenObjectSO) == false)
                {
                    return false;
                }
        }
        
        return true;
    }
    public List<RecipeSO> GetOrderlist()
    {
        return orderRecipeSOlist;                         
    }
}
