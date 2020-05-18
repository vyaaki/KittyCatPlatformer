using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private GameControl gameControl;

    private void Awake()
    {
        if (gameControl == null)
        {
            DontDestroyOnLoad(gameObject);
            gameControl = this;
            PlayerStatistic.Source().LoadFromFileIfExist();
        }
        else if (gameControl != this)
        {
            Destroy(this);
        }
    }

    private void OnApplicationQuit()
    {
        PlayerStatistic.Source().SaveData();
    }
}

[Serializable]
public class PlayerStatistic
{
    private const string SAVES_DATA_PATH = "Saves/save.dat";

    private static PlayerStatistic source;

    private PlayerStatistic()
    {
    }

    public int Scores { get; private set; }

    public static PlayerStatistic Source()
    {
        return source ?? (source = new PlayerStatistic());
    }

    public void IncreaseScore(int value)
    {
        Scores += value;
    }

    public void ResetScoreForLevel()
    {
        Scores = 0;
    }

    public void LoadFromFileIfExist()
    {
        if (File.Exists(SAVES_DATA_PATH))
        {
            var formatter = new BinaryFormatter();
            var saveFile = File.Open(SAVES_DATA_PATH, FileMode.Open);
            source = (PlayerStatistic) formatter.Deserialize(saveFile);

            saveFile.Close();
        }
    }

    public void SaveData()
    {
        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");

        var formatter = new BinaryFormatter();
        var saveFile = File.Create(SAVES_DATA_PATH);

        formatter.Serialize(saveFile, Source());

        saveFile.Close();
    }
}