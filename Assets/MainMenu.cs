using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject startPanel;

    [SerializeField]
    private GameObject statsPanel;

    [SerializeField]
    private GameObject groupPanel;

    [SerializeField]
    private Text scoreText;

    private void Start()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowStats()
    {
        for (int i = 1; i < 11; i++)
        {
            Instantiate(scoreText, groupPanel.transform).GetComponent<Text>().text = i + ". " + PlayerPrefs.GetInt(i + "score");
        }

        startPanel.SetActive(false);
        statsPanel.SetActive(true);
    }

    public void ShowMainMenu()
    {
        startPanel.SetActive(true);
        statsPanel.SetActive(false);
    }
}
