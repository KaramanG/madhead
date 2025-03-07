using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour
{
    public int killCount = 0;
    public int pointCount = 0;

    public void addKill()
    {
        killCount++;
    }

    public void addScore(int score)
    {
        pointCount += score;
    }

    public void savePlayer(int saveNumber)
    {
        saveSystem.savePlayer(this, saveNumber);
    }
    public void loadPlayer(int saveNumber)
    {
        killPointCounter data = saveSystem.loadPlayer(saveNumber);
        killCount = data.killCount;
        pointCount = data.pointCount;
    }
}
