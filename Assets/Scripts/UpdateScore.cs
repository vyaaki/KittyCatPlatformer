using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public Text UIScoreText;

    private void Update()
    {
        UIScoreText.GetComponent<Text>().text = "Score:" + PlayerStatistic.Source().LevelScores;
    }
}