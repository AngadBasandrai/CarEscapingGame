using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    public Text levelCounter;
    public Button menu;
    public Button nextLvl;
    public bool nexLevel = true;

    // Start is called before the first frame update
    void Start()
    {
        if (nexLevel)
        {
            levelCounter.text = "You Completed Level " + LevelCounter.level.ToString();
        }
        else
        {
            levelCounter.text = "You Failed Level " + LevelCounter.level.ToString();
        }
        menu.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
        nextLvl.onClick.AddListener(UpdateS);
    }

    // Update is called once per frame
    void UpdateS()
    {
        if (nexLevel)
        {
            LevelCounter.level++;
            PlayerPrefs.SetInt(PlayerPrefs.GetString("User") + "Level", LevelCounter.level);
        }
        SceneManager.LoadScene("Level" + (LevelCounter.level - 1));
    }
}
