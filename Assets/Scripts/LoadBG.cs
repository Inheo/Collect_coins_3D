using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBG : MonoBehaviour {

	public event Action<string> LoadScene;

    public string NameLoadScene = "Menu";

    public void Hidden()
    {
        // start after animate clip "HideBG"
        if(LoadScene != null)
        {
            LoadScene.Invoke(NameLoadScene);
        }
    }
}
