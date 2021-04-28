using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	private GameObject CoinPrefab;
	private GameObject HeroPrefab;

	[SerializeField] private Animation loadBGAnimation;
	[SerializeField] private Joystick joystick;
	[SerializeField] private CoinsSpawner coinsSpawner;


	[Space()]
	public Text CountCoinsText;
	public Image BackButton;
	public Image JoystickBG;
	public Image JoystickFG;

	public Action GameBegin;

	public static Game Instance;

	private void Awake()
    {
		Instance = this;
		GameBegin += StartGame;
    }

	private void StartGame()
    {
		Instantiate(HeroPrefab);
		CharacterMovement.Instance.GetComponent<CollisionCharacter>().CoinsText = CountCoinsText;
		CharacterMovement.Instance.Joystick = joystick;
		coinsSpawner.CoinPrefab = CoinPrefab;
		loadBGAnimation.Play("ShowBG");
	}


	public void RestartScene()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #region Set data
    public void SetCoinPrefab(GameObject prefab) 
	{
		CoinPrefab = prefab;
	}
	public void SetHeroPrefab(GameObject prefab) 
	{
		HeroPrefab = prefab;
	}
	public void SetButtnBG(Sprite icon)
    {
		BackButton.sprite = icon;
    }
	public void SetJoystickBG(Sprite icon)
    {
		JoystickBG.sprite = icon;
    }
	public void SetJoystickFG(Sprite icon)
    {
		JoystickFG.sprite = icon;
    }
    #endregion
}
