using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class watchScript : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI armorText;

    private void Update()
    {
        hpText.text = _player.healthPoints.ToString();
        armorText.text = _player.armorPoints.ToString();
    }
}
