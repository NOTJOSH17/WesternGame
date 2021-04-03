using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LvlOneData
{
    public bool checkpointBool;

    public bool checkpointBoolTwo;

    public LvlOneData (LevelOneCheck checker)
    {
        checkpointBool = checker.checkpointSet;
    }

    public LvlOneData (LevelTwoCheck checkerTwo)
    {
        checkpointBoolTwo = checkerTwo.checkpointSet;
    }
}
