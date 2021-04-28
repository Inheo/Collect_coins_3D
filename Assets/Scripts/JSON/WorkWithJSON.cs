using Structs;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class WorkWithJSON : MonoBehaviour {

    [SerializeField] private LoadAssetBundle loadAssetBundle;

    [SerializeField] private string url;
    [SerializeField] private int version;

    [Header("Save Config")]
    [SerializeField] private string savePath;
    [SerializeField] private string saveFileName = "data.json";


    public void LoadFromFile()
    {
        try
        {
            TextAsset file = Resources.Load("data") as TextAsset;
            string json = file.ToString();

            JSONStruct jsonStruct = JsonUtility.FromJson<JSONStruct>(json);
            this.version = jsonStruct.version;
            this.url = jsonStruct.url;
        }
        catch (Exception e)
        {
            Debug.Log("{GameLog} - [GameCore] - (<color=red>Error</color>) - LoadFromFile -> " + e.Message);
        }
    }

    private void Awake()
    {
        LoadFromFile();

        loadAssetBundle.url = url;
        loadAssetBundle.version = version;
    }
}
