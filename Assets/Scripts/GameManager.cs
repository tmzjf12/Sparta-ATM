using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UserData userData;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadUserData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveUserData()
    {
        PlayerPrefs.SetString("UserName",userData.userName);
        PlayerPrefs.SetInt("UserCash", userData.userCash);
        PlayerPrefs.SetInt("UserBalance", userData.userBalance);
        PlayerPrefs.Save();
        
    }

    private void LoadUserData()
    {
        if (PlayerPrefs.HasKey("UserName")) // 데이터가 있다면
        {
            userData.userName = PlayerPrefs.GetString("UserName");
            userData.userCash = PlayerPrefs.GetInt("UserCash");
            userData.userBalance = PlayerPrefs.GetInt("UserBalance");
        }
        else // 없으면
        {
            SaveUserData();
        }
    }
    
    
}
    

