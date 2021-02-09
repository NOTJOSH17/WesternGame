using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LvlOneData
{
    public bool checkpointBool;

    public LvlOneData (LevelOneCheck checker)
    {
        checkpointBool = checker.checkpointSet;
    }
}
