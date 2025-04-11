using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    private int volume = 5;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        OrderMananger.Instance.OnRecipeSuccessed += Instance_OnRecipeSuccessed;
        OrderMananger.Instance.OnRecipeFailed += Instance_OnRecipeFailed;
        CuttingCounter.OnCut += CuttingCounter_OnCut;
        KitchenObjectHolder.OnDrop += KitchenObjectHolder_OnDrop;
        KitchenObjectHolder.OnPickup += KitchenObjectHolder_OnPickup;
        TrashCounter.OnObjectTrashed += TrashCounter_OnObjectTrashed;
    }

    private void TrashCounter_OnObjectTrashed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.trash);
    }

    private void KitchenObjectHolder_OnPickup(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.objectPickup);
    }

    private void KitchenObjectHolder_OnDrop(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.objectDrop);
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.chop);
    }

    private void Instance_OnRecipeFailed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.deliverFail);
    }

    private void Instance_OnRecipeSuccessed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.deliverSuccess);
    }

    private
        void PlaySound(AudioClip[] clips, float volumeMultipler = 1.0f)
    {
        PlaySound(clips, Camera.main.transform.position, volumeMultipler);
    }
    private void PlaySound(AudioClip[] clips,Vector3 position,float volumeMultipler = 1.0f)
    {
        int index = Random.Range(0, clips.Length);
        AudioSource.PlayClipAtPoint(clips[index], position, volumeMultipler * (volume/10.0f));
    }
    public void PlayerSound(float volumeMultipler = .1f)
    {
        
        PlaySound(audioClipRefsSO.footstep, volumeMultipler);
    }

    public void ChangeVolume()
    {
        volume++;
        if (volume > 10)
        {
            volume = 0;
        }
    }
    public int GetVolume()
    {
        return volume;
    }
}
