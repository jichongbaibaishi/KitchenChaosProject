using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dotText;

    private float dotRate = 0.3f;

    private void Start()
    {
        StartCoroutine(DotAnimation());
    }

    IEnumerator DotAnimation()
    {
        while (true)
        {
            dotText.text = ".";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "..";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "...";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "....";
            yield return new WaitForSeconds(dotRate);
            dotText.text = ".....";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "......";
            yield return new WaitForSeconds(dotRate);
        }
    }
}
