using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    string levelKey = "LevelCount";  
    public int levelAmount;
    public int deleteSave;
    void Awake()
    {
        deleteSave = PlayerPrefs.GetInt("DeleteCount");
        PlayerPrefs.SetInt("DeleteCount", deleteSave);
        //Debug.Log((PlayerPrefs.GetInt("DeleteCount").ToString()));

        levelAmount = PlayerPrefs.GetInt("LevelCount");
        PlayerPrefs.SetInt("LevelCount", levelAmount);
        //Debug.Log((PlayerPrefs.GetInt(levelKey).ToString()));
    }

    public void Reset() 
    {
        PlayerPrefs.DeleteKey(levelKey);
    }

    public void AddAmount()
    {
        levelAmount += 1;
        PlayerPrefs.SetInt("LevelCount", levelAmount);
    }

}
