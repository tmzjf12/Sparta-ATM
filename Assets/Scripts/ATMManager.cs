using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ATMManager : MonoBehaviour
{

    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI cashText;
    public Button depositButton;
    public Button withdrawButton;

    public int balance = 50000;
    public int cash = 100000;

    void UpdateUI()
    {
        balanceText.text = string.Format("{0:N0}", balance);
        cashText.text = string.Format("{0:N0}", cash);
    }
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        UpdateUI();
    }
}
