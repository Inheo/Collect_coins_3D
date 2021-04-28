using UnityEngine;

public class Click : MonoBehaviour
{
    private AudioSource clickAudio;
    
    private void Start()
    {
        clickAudio = GetComponent<AudioSource>();
    }

    public void ClickPlay()
    {
        if(bool.Parse(PlayerPrefs.GetString("SFX", "True")))
            clickAudio.Play();
    }
}
