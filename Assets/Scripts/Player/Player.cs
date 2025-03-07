using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] gameOverScript deathScript;

    private int HealthPoints
    {
        set
        {
            if (value < 0)
                healthPoints = 0;
            else
                healthPoints = value;
        }
    }
    public int healthPoints = 100;

    private int ArmorPoints
    {
        set
        {
            if (value < 0)
                armorPoints = 0;
            else
                armorPoints = value;
        }
    }
    public int armorPoints = 100;
    
    public void receiveDamage(int damage)
    {
        if (armorPoints > 0)
        {
            ArmorPoints = armorPoints - damage;
            HealthPoints = healthPoints - (damage / 2);
        }
        else
            HealthPoints = healthPoints - damage;
    }

    private void Update()
    {
        if (healthPoints <= 0)
        {
            deathScript.playerDeath();
        }
    }
}
