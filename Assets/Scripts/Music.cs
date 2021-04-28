using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour 
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        CheckValue();
    }
	
	public void CheckValue()
    {
        if(bool.Parse(PlayerPrefs.GetString("Music", true.ToString())))
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
