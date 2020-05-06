using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public Text UIScoreText;
    public static int ScoreCounter = 0;
    void Update()
    {
        UIScoreText.GetComponent<Text>().text = "Score:" + ScoreCounter;
    }
}
