using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SavestatesManager : MonoBehaviour
{
    private const string PATH_TO_SAVESTATES_DIRECTORY = "Assets/Savestates/";

    [SerializeField]
    private GameDataAggregate _gameDataAggregate;

    public bool SaveGame(string savestateName)
    {
        return WriteDataToFile(PATH_TO_SAVESTATES_DIRECTORY, savestateName, JsonUtility.ToJson(_gameDataAggregate, true));
    }

    public void LoadGame(string savestateName)
    {
        _gameDataAggregate = JsonUtility.FromJson<GameDataAggregate>(ReadDataFromFile(PATH_TO_SAVESTATES_DIRECTORY, savestateName));
    }

    private string ReadDataFromFile(string directory, string savestateName)
    {
        StreamReader reader = new StreamReader(directory + savestateName);
        string data = reader.ReadToEnd();
        reader.Close();

        return data;
    }

    private bool WriteDataToFile(string directory, string savestateName, string data)
    {
        StreamWriter writer = new StreamWriter(directory + savestateName, false);
        writer.WriteLine(data);
        writer.Close();

        AssetDatabase.ImportAsset(directory + savestateName);
        TextAsset asset = (TextAsset) Resources.Load(savestateName);
        return data.Equals(asset.text);
    }
}
