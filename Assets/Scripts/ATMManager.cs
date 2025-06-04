using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ATMManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI cashText;
    public Button depositButton;
    public Button withdrawButton;
    
    public UserData userData;

    // public int balance = 50000;
    // public int cash = 100000;  -스텝1 기본 값

    public void Refresh()
    {
        if ( userData != null )
        {
            balanceText.text = string.Format("{0:N0}", userData.userBalance);
            cashText.text = string.Format("{0:N0}", userData.userCash);
        }
    }
    
    
    void UpdateUI()
    {
        // balanceText.text = string.Format("{0:N0}",balance);
        // cashText.text = string.Format("{0:N0}",cash); - 스텝1 기본 값
        nameText.text = userData.userName;
        balanceText.text = string.Format("{0:N0}", userData.userBalance);
        cashText.text = string.Format("{0:N0}", userData.userCash);
    }
    
    
    void Start()
    {
        userData = GameManager.instance.userData;
        UpdateUI();
    }

    
    
}
