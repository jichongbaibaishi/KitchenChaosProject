using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryResultUI : MonoBehaviour
{
    private const string IS_SHOW = "isShow";
    [SerializeField]private Animator deliverySuccessAnimator;
    [SerializeField]private Animator deliveryFailureAnimator;
    // Start is called before the first frame update
    void Start()
    {
        OrderMananger.Instance.OnRecipeSuccessed += OrderManager_OnRecipeSuccessed;
        OrderMananger.Instance.OnRecipeFailed += OrderManager_OnRecipeFailed;
    }

    private void OrderManager_OnRecipeSuccessed(object sender, System.EventArgs e)
    {
        deliverySuccessAnimator.gameObject.SetActive(true);
        deliverySuccessAnimator.SetTrigger(IS_SHOW);
    }

    private void OrderManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        deliveryFailureAnimator.gameObject.SetActive(true);
        deliveryFailureAnimator.SetTrigger(IS_SHOW);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
