using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
   public string userName;
   public int userCash;
   public int userBalance;

   public UserData(string name, int cash, int balance)
   {
      userName = name;
      userCash = cash;
      userBalance = balance;
   }
   
}
