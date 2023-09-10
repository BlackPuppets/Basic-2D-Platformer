using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    [SerializeField] private TextMeshProUGUI coinText;
    private int coins;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        ResetItems();
    }

    private void ResetItems()
    {
        coins = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        coinText.text = "x " + coins.ToString();

    }
}
