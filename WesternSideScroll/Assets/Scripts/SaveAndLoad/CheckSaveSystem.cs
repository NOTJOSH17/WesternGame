using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class CheckSaveSystem
{
 public static void SaveCheckpoint(LevelOneCheck checker)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        LvlOneData data = new LvlOneData(checker);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LvlOneData LoadLevelCheckpoint()
    {
        string path = Application.persistentDataPath + "/level.save";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LvlOneData  data = formatter.Deserialize(stream) as LvlOneData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
