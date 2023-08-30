using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Button play;
    public Button scenes;
    public Button close;
    public GameObject levels;

    void Start()
    {
        play.onClick.AddListener(() => SceneManager.LoadScene("Level" + PlayerPrefs.GetInt(PlayerPrefs.GetString("User") + "Level")));
        scenes.onClick.AddListener(() => levels.SetActive(true));
        close.onClick.AddListener(() => levels.SetActive(false));
        foreach (Button button in FindObjectsOfType<Button>())
        {
            if (button != play && button != scenes && button != close)
            {
                button.onClick.AddListener(() => SceneManager.LoadScene("Level" + (int.Parse(button.gameObject.name) - 1)));
                if (int.Parse(button.gameObject.name) - 1 <= PlayerPrefs.GetInt(PlayerPrefs.GetString("User") + "Level"))
                {
                    button.interactable = true;
                }
                else
                {
                    button.interactable = false;
                }
            }
        }
        levels.SetActive(false);
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Select"))
        {
            SceneManager.LoadScene("Level" + PlayerPrefs.GetInt(PlayerPrefs.GetString("User") + "Level"));
        }
    }
}
