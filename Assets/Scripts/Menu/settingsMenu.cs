using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    
    public void closeWindow()
    {
        settingsPanel.SetActive(false);
    }
}
