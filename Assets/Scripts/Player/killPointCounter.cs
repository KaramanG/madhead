using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class killPointCounter
{
    public int killCount;
    public int pointCount;

    public killPointCounter(playerData data)
    {
        killCount = data.killCount;
        pointCount = data.pointCount;
    }
}
