using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Variables
    private PlayerController pCScript;
    private TMP_Text coinCounter;
    private TMP_Text playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        pCScript = GameObject.Find("Player").GetComponent<PlayerController>();
        coinCounter = GameObject.Find("CoinDisplay").GetComponent<TMP_Text>();
        playerStatus = GameObject.Find("PlayerStatus").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        displayPlayerStat();
    }

    private void displayCoinCount()
    {
        if(!pCScript.isDead || !pCScript.gameWon)
        {
            coinCounter.text = $"Coin Count: {pCScript.coinCount}";
        }
    }

    private void displayPlayerStat()
    {
        if (pCScript.isDead)
        {
            playerStatus.text = "You've died!";
            coinCounter.text = "";

        } else if (pCScript.gameWon)
        {
            playerStatus.text = "You've won the game!";
            coinCounter.text = "";

        } else
        {
            displayCoinCount();
        }
    }
}
