using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [Serializable]
    public class CuttingRecipe
    {
        public KitchenObjectSO input;
        public KitchenObjectSO output;
        public int cuttingCountMax;
    }
    [CreateAssetMenu()]
    public class CuttingRecipeListSO : ScriptableObject
    {
        public List<CuttingRecipe> List;

        public KitchenObjectSO GetOutput(KitchenObjectSO input) 
        {
        foreach(CuttingRecipe recipe in List)
        { 
            if (recipe.input == input)  
            {
            return recipe.output;
            }
        }
        return null;
    
        }
    public bool TryGetCuttingRecipe(KitchenObjectSO input,out CuttingRecipe cuttingRecipe)
    {
        foreach (CuttingRecipe recipe in List)
        {
            if (recipe.input == input)
            {
                cuttingRecipe = recipe; return true;
            }
        }
        cuttingRecipe = null;
        return false;
    }
}


