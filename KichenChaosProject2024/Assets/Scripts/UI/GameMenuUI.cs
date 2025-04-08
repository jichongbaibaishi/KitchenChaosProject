using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuUI : MonoBehaviour
{
    [SerializeField] private Button startbutton;
    [SerializeField] private Button endbutton;
    void Start()
    {
        startbutton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });
        endbutton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Show() { 
    
    }
}
