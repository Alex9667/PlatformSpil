using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter Instance;
    public TMP_Text CoinText;
    public int CurrentCoins;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        CoinText.text = "Money: " + CurrentCoins.ToString();
    }

    // Update is called once per frame
    public void IncreaseCoins(int amount)
    {
        CurrentCoins += amount;
        CoinText.text = "Money: " + CurrentCoins.ToString();
    }
}
