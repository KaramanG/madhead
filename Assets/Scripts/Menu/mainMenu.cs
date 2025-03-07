using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject settingsPanel;   
    [SerializeField] private GameObject savePanel;

    [SerializeField] private Button continueGameButton;

    [SerializeField] private GameObject startGameText;

    public void openSettings()
    {
        settingsPanel.SetActive(true);
    }
    public void closeSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void continueGame()
    {
        savePanel.SetActive(true);
    }

    public void closeContinueGame()
    {
        savePanel.SetActive(false);
    }

    public void closeGame()
    {
        Application.Quit();
    }

    public void closeMenu()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        startGameText.SetActive(false);
    }
}
