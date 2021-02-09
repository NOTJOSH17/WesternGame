using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{

    public int health;
    public int bullets;
    public bool testBool;

    public GameData (PlayerCntrl player)
    {
        health = player.health;
        bullets = player.bulletCount;
        testBool = player.testBool;
    }
}
