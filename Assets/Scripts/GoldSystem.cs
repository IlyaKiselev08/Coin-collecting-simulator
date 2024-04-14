using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldSystem : MonoBehaviour
{
    public static GoldSystem Instance { get; private set; }

    public float goldBank;
    public TextMeshProUGUI _goldBankText;
    public float goldAmount;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        goldAmount = FindObjectsOfType<Coin>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddGold(float goldAmount)
    {
        goldBank += goldAmount;
        _goldBankText.text = "Монет собрано: " + goldBank.ToString() + " / " + this.goldAmount.ToString();
    }
}
