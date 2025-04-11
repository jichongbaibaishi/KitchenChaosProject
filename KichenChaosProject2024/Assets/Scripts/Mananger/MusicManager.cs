using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance {  get; private set; }
    private AudioSource audioSource;
    private float orginalVolume;
    private int volume = 5;
    // Start is called before the first frame update
    private void Awake()
    {
       instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        orginalVolume = audioSource.volume;
        UpdateVolume();
    }
    private void UpdateVolume()
    {
        audioSource.volume = (volume / 10.0f) * orginalVolume;
    }
    public void changeVolume()
    {
        volume++;
        if (volume > 10) {
        volume = 0;}
        UpdateVolume();
    }

    // Update is called once per frame
    public int GetVolume() { 
    return volume;
    
    }
    void Update()
    {
        
    }
}
