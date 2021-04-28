using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour {

	public GameObject CoinPrefab;

    [SerializeField] private Transform parentCoins;
	[SerializeField] private Vector3 limitPosition = new Vector3(7, 10, 7);

	private void Start()
    {
        Game.Instance.GameBegin += StartSpawn;
    }

    private void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

	private IEnumerator Spawn()
    {
        while (true) 
        {
            Vector3 randomPosition = new Vector3(Random.Range(-limitPosition.x, limitPosition.x), 10, Random.Range(-limitPosition.z, limitPosition.z));
            GameObject coin = Instantiate(CoinPrefab, randomPosition, Quaternion.identity);
            coin.transform.SetParent(parentCoins);
            coin.tag = "Coin";
            yield return new WaitForSeconds(Random.Range(0.5f, 1));
        }
    }
}
