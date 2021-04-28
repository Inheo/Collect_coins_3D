using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionCharacter : MonoBehaviour
{
    public Text CoinsText;

    private int coinsCount = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Coin"))
        {
            coinsCount++;
            UpdateUI();
            Destroy(collision.gameObject);
        }
    }

    private void UpdateUI()
    {
        CoinsText.text = "Coins: " + coinsCount;
    }
}
