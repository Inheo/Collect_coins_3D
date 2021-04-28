using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundle : MonoBehaviour 
{

	[SerializeField] CheckInternet checkInternet;

	public string url = "https://drive.google.com/uc?export=download&id=1iA4SP4Bx2g37Pzl1SfYth2uD-tdl7x3b";
	public int version = 0;

	// Use this for initialization
	private void Start () 
	{
		StartCoroutine(DownloadAndCache());
	}
	
	private IEnumerator DownloadAndCache()
    {
        while (!checkInternet.Verified)
        {
            yield return null;
        }

        if (!checkInternet.Access && PlayerPrefs.GetInt("FirstEntry", 0) == 0)
        {
            yield break;
        }

        while (!Caching.ready)
        {
			yield return null;
        }

		var www = WWW.LoadFromCacheOrDownload(url, version);
		yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
			Debug.Log(www.error);
			yield break;
        }

		PlayerPrefs.SetInt("FirstEntry", 1);
		
		Debug.Log("Succes download");

		var assetBundle = www.assetBundle;
        #region Name Bundle
        string coinName = "Coin.prefab";
		string heroName = "Hero.prefab";
		string buttonBG_name = "ButtonBG.png";
		string joystickBG_name = "JoystickBG.png";
		string joystickFG_name = "JoystickFG.png";
        #endregion
        #region Request
        var coinReq = assetBundle.LoadAssetAsync(coinName, typeof(GameObject));
        yield return coinReq;

        var heroReq = assetBundle.LoadAssetAsync(heroName, typeof(GameObject));
        yield return heroReq;

        var buttonBG_req = assetBundle.LoadAssetAsync(buttonBG_name, typeof(Sprite));
        yield return buttonBG_req;

        var joystickBG_req = assetBundle.LoadAssetAsync(joystickBG_name, typeof(Sprite));
        yield return joystickBG_req;

        var joystickFG_req = assetBundle.LoadAssetAsync(joystickFG_name, typeof(Sprite));
        yield return joystickFG_req;
        #endregion

        GameObject coin = coinReq.asset as GameObject;
        GameObject hero = heroReq.asset as GameObject;
        Sprite button = buttonBG_req.asset as Sprite;
        Sprite joystickBG = joystickBG_req.asset as Sprite;
        Sprite joystickFG = joystickFG_req.asset as Sprite;

        #region Set Data
        Game.Instance.SetCoinPrefab(coin);
		Game.Instance.SetHeroPrefab(hero);
		Game.Instance.SetButtnBG(button);
		Game.Instance.SetJoystickBG(joystickBG);
		Game.Instance.SetJoystickFG(joystickFG);
		#endregion

        if (Game.Instance.GameBegin != null)
		{
			Game.Instance.GameBegin.Invoke();
		}

        assetBundle.Unload(false);
    }
}
