using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationBetweenScreens : MonoBehaviour
{
    [SerializeField] private Animator canvasAnimator;

    public void ShowOrHideSettings(bool value)
    {
        canvasAnimator.SetBool("ShowSettings", value);
    }
}
