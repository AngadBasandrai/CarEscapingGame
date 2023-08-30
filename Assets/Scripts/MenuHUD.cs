using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHUD : MonoBehaviour
{
    public InputField username;
    public InputField password;
    public InputField confirmPassword;
    public Button confirm;
    public Text invalid;
    public Text invalidConfirm;

    // Start is called before the first frame update
    void Start()
    {
        confirm.onClick.AddListener(Login);        
    }

    void Login()
    {
        if (PlayerPrefs.GetString(username.text) != null && PlayerPrefs.GetString(username.text) != "\0" && PlayerPrefs.GetString(username.text) != "" && PlayerPrefs.GetString(username.text) != " ")
        {
            if (PlayerPrefs.GetString(username.text) == password.text)
            {
                PlayerPrefs.SetString("User", username.text);
                SceneManager.LoadScene("Menu");
            }
            else
            {
                confirmPassword.gameObject.SetActive(false);
                invalidConfirm.gameObject.SetActive(false);
                invalid.gameObject.SetActive(true);
            }
        }
        else
        {
            if (confirmPassword.gameObject.activeSelf)
            {
                if (confirmPassword.text == password.text)
                {
                    PlayerPrefs.SetString(username.text, confirmPassword.text);
                    PlayerPrefs.SetString("User", username.text);
                    PlayerPrefs.SetInt(PlayerPrefs.GetString("User") + "Level", 0);
                    SceneManager.LoadScene("Menu");
                }
                else
                {
                    invalidConfirm.gameObject.SetActive(true);
                }
            }
            else 
            {
                confirmPassword.gameObject.SetActive(true);
            }
        }
    }
}
