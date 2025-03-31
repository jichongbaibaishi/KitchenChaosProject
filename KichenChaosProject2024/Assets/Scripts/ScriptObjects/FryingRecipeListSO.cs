using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu()]
public class FryingRecipeListSO : ScriptableObject
{
    public List<FryingRecipe> List;

    public bool TryGetFryingRecipe(KitchenObjectSO input, out FryingRecipe fryingRecipe)
    {
        foreach (FryingRecipe recipe in List)
        {
            if (recipe.input == input)
            {
                fryingRecipe = recipe; return true;
            }
        }
        fryingRecipe = null;
        return false;
    }
}

[Serializable]
public class FryingRecipe
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float fryingTime;
}
