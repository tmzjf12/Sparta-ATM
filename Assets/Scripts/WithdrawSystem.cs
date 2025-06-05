using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WithdrawSystem : MonoBehaviour
{
   [Header("UI")] 
   public Button button10000;
   public Button button30000;
   public Button button50000;
   public InputField customInput;
   public Button withdrawButton;

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
   

   public void InstantWithdraw(int amount)
   {
      if (userData.userBalance < amount)
      {
         ShowBalancePopup();
         return;
      }

      else
      {
         userData.userBalance -= amount;
         userData.userCash += amount;
         
         GameManager.instance.SaveUserData();
         
      }

      UpdateDisplay();

   }
   
   
   
   
   void Start()
   {
      userData = GameManager.instance.userData;
      
      button10000.onClick.AddListener(() => InstantWithdraw(10000));
      button30000.onClick.AddListener(() => InstantWithdraw(30000));
      button50000.onClick.AddListener(() => InstantWithdraw(50000));

      withdrawButton.onClick.AddListener(CustomInput);
      popupOKButton.onClick.AddListener(ClosePopup);
      
      UpdateDisplay();


   }

   public void CustomInput()
   {
      if (int.TryParse(customInput.text, out int amount))
      {
         if (userData.userBalance < amount)
         {
            ShowBalancePopup();
            return;
         }

         if (amount > 0)
         {
            userData.userBalance -= amount;
            userData.userCash += amount;
            customInput.text = "";
            UpdateDisplay();
            
         }
         
      }
   }
   
}
