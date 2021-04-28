using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class CreateAssetBundle : MonoBehaviour 
{
    [MenuItem("Assets/Build Asset Bundles ")]

    static void BuildAssetBundles()
    {
        string AssetBundleDirectory = "Assets/AssetBundle";

        if (!Directory.Exists(AssetBundleDirectory))
        {
            Directory.CreateDirectory(AssetBundleDirectory);
        }

        BuildPipeline.BuildAssetBundles(AssetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}
