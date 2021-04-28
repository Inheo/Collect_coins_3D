using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Animator SFX_animator;
    [SerializeField] private Animator musicAnimator;

    [SerializeField] private Toggle SFX_toggle;
    [SerializeField] private Toggle musicToggle;

    private void Start()
    {
        CheckSounds();
    }

    public void SFXValueChange(bool value)
    {
        SFX_animator.SetBool("On", value);
        PlayerPrefs.SetString("SFX", value.ToString());
    }

    public void MusicValueChange(bool value)
    {
        musicAnimator.SetBool("On", value);
        PlayerPrefs.SetString("Music", value.ToString());
    }

    private void CheckSounds()
    {
        bool isSFXOn = bool.Parse(PlayerPrefs.GetString("SFX", "True"));
        SFX_animator.SetBool("On", isSFXOn);
        SFX_toggle.isOn = isSFXOn;

        bool isMusicOn = bool.Parse(PlayerPrefs.GetString("Music", "True"));
        musicAnimator.SetBool("On", isMusicOn);
        musicToggle.isOn = isMusicOn;
    }
}
