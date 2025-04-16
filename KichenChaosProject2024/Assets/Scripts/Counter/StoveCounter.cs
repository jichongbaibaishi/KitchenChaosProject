using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StoveCounter : BaseCounter {

    [SerializeField] private FryingRecipeListSO fryingRecipeList;
    [SerializeField] private FryingRecipeListSO burningRecipeList;
    [SerializeField]private StoveCounterVisual StoveCounterVisual;
    [SerializeField]private ProgressbarUI progressBarUI;
    public enum StoveState
    {
        Idle,
        Frying,
        Burning
    }

    private FryingRecipe fryingRecipe;
    private float fryingTimer = 0;
    private StoveState state = StoveState.Idle;
    private WarningControl warningControl;
    [SerializeField] private AudioSource sound;

    private void Start()
    {
        warningControl=GetComponent<WarningControl>();
    }
    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {//手上有食材
            if (IsHaveKitchenObject() == false)
            {//当前柜台为空
                if(fryingRecipeList.TryGetFryingRecipe(player.GetKitchenObject().GetKitchenObjectSO(), out FryingRecipe fryingRecipe)){

                    TransferKitchenObject(player, this);
                    StartFrying(fryingRecipe);
                    
                }
                else if(burningRecipeList.TryGetFryingRecipe(player.GetKitchenObject().GetKitchenObjectSO(), out FryingRecipe burningRecipe))
                {

                    TransferKitchenObject(player, this);
                    StartBurning(burningRecipe);
                }
                else
                {

                }
                
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
                TurnToIdle();
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
                progressBarUI.UpdateProgress(fryingTimer / fryingRecipe.fryingTime);
                if (fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    state = StoveState.Burning;

                    burningRecipeList.TryGetFryingRecipe(GetKitchenObject().GetKitchenObjectSO(),
                        out FryingRecipe newFryingRecipe);
                    StartBurning(newFryingRecipe);
                }
                break;
            case StoveState.Burning:
                fryingTimer += Time.deltaTime;
                progressBarUI.UpdateProgress(fryingTimer / fryingRecipe.fryingTime);
                float warningTimeNormalize = .5f;
                if (fryingTimer / fryingRecipe.fryingTime > warningTimeNormalize)
                {
                    warningControl.ShowWarning();
                }
                if (fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    TurnToIdle();
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
        StoveCounterVisual.ShowStoveEffect();
        sound.Play();
    }

    private void StartBurning(FryingRecipe fryingRecipe)
    {
        if (fryingRecipe == null)
        {
            Debug.LogWarning("无法获取Burning的食谱，无法进行Burning.");
            TurnToIdle();
            return;
        }
       
        fryingTimer = 0;
        this.fryingRecipe = fryingRecipe;
        state = StoveState.Burning;
        StoveCounterVisual.ShowStoveEffect();
    }
    private void TurnToIdle()
    {
        progressBarUI.Hide();
        state = StoveState.Idle;
        StoveCounterVisual.HideStoveEffect();
        sound.Pause();
        warningControl.StopWarning();
    }
}
   

