using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public GameObject depositUI;
    public GameObject withdrawUI;
    
    public Button depositButton;
    public Button withdrawButton;
    public Button depositBackButton;
    public Button withdrawBackButton;
   

    public void ShowDepositUI()
    {
        depositUI.SetActive(true);
        depositButton.gameObject.SetActive(false);
        withdrawButton.gameObject.SetActive(false);
    }

    public void ShowWithdrawUI()
    {
        withdrawUI.SetActive(true);
        depositButton.gameObject.SetActive(false);
        withdrawButton.gameObject.SetActive(false);
    }

    public void HideUI()
    {
        depositUI.SetActive(false);
        withdrawUI.SetActive(false);
        depositButton.gameObject.SetActive(true);
        withdrawButton.gameObject.SetActive(true);
    }
    
    void Start()
    {
        
            depositButton.onClick.AddListener(ShowDepositUI);
            withdrawButton.onClick.AddListener(ShowWithdrawUI);
            depositBackButton.onClick.AddListener(HideUI);
            withdrawBackButton.onClick.AddListener(HideUI);
    
            depositUI.SetActive(false);
            withdrawUI.SetActive(false);
        
    }


}
