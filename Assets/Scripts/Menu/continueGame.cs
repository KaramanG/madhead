using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class continueGame : MonoBehaviour
{
    [SerializeField] private Button continueGameButton;
    [SerializeField] private playerData data;

    [SerializeField] private Button load1;
    [SerializeField] private Button load2;
    [SerializeField] private Button load3;

    void Start()
    {
        continueGameButton.interactable = false;   
    }

    private void Update()
    {
        if (saveSystem.exists(1) || saveSystem.exists(2) || saveSystem.exists(3))
        {
            continueGameButton.interactable = true;
        }

        buttonBehavior(1, load1);
        buttonBehavior(2, load2);
        buttonBehavior(3, load3);
    }

    public void saveToSlot(int slot)
    {
        saveSystem.savePlayer(data, slot);
    }

    public void loadFromSlot(int slot)
    {
        killPointCounter dataCounter = saveSystem.loadPlayer(slot);
        data.killCount = dataCounter.killCount;
        data.pointCount = dataCounter.pointCount;
    }

    public void buttonBehavior(int slot, Button button)
    {
        if (saveSystem.exists(slot))
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }    
}
