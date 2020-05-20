using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl gameControl;

    private void Awake()
    {
        if (gameControl == null)
        {
            gameControl = this;
            PlayerStatistic.Source().LoadFromFileIfExist();
        }
        else if (gameControl != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnApplicationQuit()
    {
        PlayerStatistic.Source().SaveData();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex > 0) PlayerStatistic.Source().ResetScoreForLevel();
    }
}

public class PlayerCustomization
{
    private static PlayerCustomization source;

    public static AnimatorController usedAnimatorController;

    public static PlayerCustomization Source()
    {
        return source ?? (source = new PlayerCustomization());
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

    public int LevelScores { get; private set; }
    public int Scores { get; private set; }

    public static PlayerStatistic Source()
    {
        return source ?? (source = new PlayerStatistic());
    }

    public void IncreaseLevelScore(int value)
    {
        LevelScores += value;
    }

    public void IncreaseTotalScore()
    {
        Scores += LevelScores;
    }

    public void ResetScoreForLevel()
    {
        LevelScores = 0;
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