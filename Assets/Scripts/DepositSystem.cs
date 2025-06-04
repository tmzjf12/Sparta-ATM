using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DepositSystem : MonoBehaviour
{
   [Header("UI")] 
   public Button button10000;
   public Button button30000;
   public Button button50000;
   public InputField customInput;
   public Button depositButton;

   [Header("Popup")] 
   public GameObject balancePopup; // 잔액부족팝업
   public Button popupOKButton; // 확인버튼
   
   [Header("Balance")] 
   public TextMeshProUGUI balanceText;
   public TextMeshProUGUI cashText;
   
   private UserData userData;


   public void ShowBalancePopup()
   {
      balancePopup.SetActive(true);
   }

   public void ClosePopup()
   {
      balancePopup.SetActive(false);
   }

   private void UpdateDisplay()
   {
      balanceText.text = userData.userBalance.ToString();
      cashText.text = userData.userCash.ToString();
   }
   

   public void InstantDeposit(int amount)
   {
      if (userData.userCash < amount)
      {
         ShowBalancePopup();
         return;
      }

      else
      {
         userData.userCash -= amount;
         userData.userBalance += amount;
         
      }

      UpdateDisplay();

   }
   
   
   
   
   void Start()
   {
      userData = GameManager.instance.userData;
      
      button10000.onClick.AddListener(() => InstantDeposit(10000));
      button30000.onClick.AddListener(() => InstantDeposit(30000));
      button50000.onClick.AddListener(() => InstantDeposit(50000));

      depositButton.onClick.AddListener(CustomInput);
      popupOKButton.onClick.AddListener(ClosePopup);
      
      UpdateDisplay();


   }

   public void CustomInput()
   {
      if (int.TryParse(customInput.text, out int amount))
      {
         if (userData.userCash < amount)
         {
            ShowBalancePopup();
            return;
         }

         if (amount > 0)
         {
            userData.userCash -= amount;
            userData.userBalance += amount;
            customInput.text = "";
            UpdateDisplay();
            
         }
         
      }
   }
   
}
