using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    //private int coins = 0;

    [SerializeField] private Text coinsText;

    private void Awake()
    {
        coinsText.text = "Coins: " + StateNameController.AllCoins;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            //Destroy(collision.gameObject);
            StateNameController.AllCoins++;
            coinsText.text = "Coins: " + StateNameController.AllCoins;        
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
