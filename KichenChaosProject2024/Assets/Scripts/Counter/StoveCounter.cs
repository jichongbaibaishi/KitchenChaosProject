using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StoveCounter : BaseCounter {

    [SerializeField] private FryingRecipeListSO fryingRecipeList;

    public enum StoveState
    {
        Idle,
        Frying,
        Burning
    }

    private FryingRecipe fryingRecipe;
    private float fryingTimer = 0;
    private StoveState state = StoveState.Idle;

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {//手上有食材
            if (IsHaveKitchenObject() == false&&fryingRecipeList.TryGetFryingRecipe(
        player.GetKitchenObject().GetKitchenObjectSO(),out FryingRecipe fryingRecipe))
            {//当前柜台为空
                
                TransferKitchenObject(player, this);
                StartFrying(fryingRecipe);
            }
            else
            {//当前柜台不为空

            }
        }
        else
        {//手上没食材
            if (IsHaveKitchenObject() == false)
            {//当前柜台为空

            }
            else
            {//当前柜台不为空
                TransferKitchenObject(this, player);
                
            }
        }
    }

    private void Update()
    {
        switch (state)
        {
            case StoveState.Idle:
                break;
            case StoveState.Frying:
                fryingTimer += Time.deltaTime;
                if (fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    state = StoveState.Burning;

                    fryingRecipeList.TryGetFryingRecipe(GetKitchenObject().GetKitchenObjectSO(),
                        out FryingRecipe newFryingRecipe);
                    StartBurning(newFryingRecipe);
                }
                break;
            case StoveState.Burning:
                fryingTimer += Time.deltaTime;
                if (fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    state = StoveState.Idle;
                }
                break;
            default:
                break;
        }

    }

    private void StartFrying(FryingRecipe fryingRecipe)
    {
        fryingTimer = 0;
        this.fryingRecipe = fryingRecipe;
        state = StoveState.Frying;
    }

    private void StartBurning(FryingRecipe fryingRecipe)
    {
        if (fryingRecipe == null)
        {
            Debug.LogWarning("无法获取Burning的食谱，无法进行Burning.");
                state = StoveState.Idle;
            return;
        }
       
        fryingTimer = 0;
        this.fryingRecipe = fryingRecipe;
        state = StoveState.Burning;
    }

}
   

