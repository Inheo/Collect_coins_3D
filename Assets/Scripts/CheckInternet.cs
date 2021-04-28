using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInternet : MonoBehaviour 
{
    public bool Access { get; private set; }
    public bool Verified { get; private set; }

    [SerializeField] private GameObject errorPanel;
    [SerializeField] private GameObject warningPanel;
    
    private void Awake()
    {
        Access = false;
        Verified = false;
        StartCoroutine(Check());
    }

    private IEnumerator Check()
    {
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
            Access = false;
        }
        else
        {
            Access = true;
        }

        Verified = true;

        if(!Access && PlayerPrefs.GetInt("FirstEntry", 0) == 0)
        {
            errorPanel.SetActive(true);
        }
        else if (!Access)
        {
            warningPanel.SetActive(true);
        }
    }
}
