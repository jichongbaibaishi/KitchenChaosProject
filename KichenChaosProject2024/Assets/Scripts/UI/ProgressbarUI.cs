using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressbarUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private Image progressImage;
   public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
    public void UpdateProgress(float progress) {
        Show();
        progressImage.fillAmount = progress;
        if (progress == 1)
        {
            Invoke("Hide", 0.5f);
        }
    }
}
