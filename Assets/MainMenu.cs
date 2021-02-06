using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject startPanel;

    [SerializeField]
    private GameObject statsPanel;

    private void Start()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowStats()
    {
        startPanel.SetActive(false);
        statsPanel.SetActive(true);
    }

    public void ShowMainMenu()
    {
        startPanel.SetActive(true);
        statsPanel.SetActive(false);
    }
}
