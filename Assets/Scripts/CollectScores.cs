using UnityEngine;

public class CollectScores : MonoBehaviour
{
    public AudioSource collectSound;
    public int ScoreValue = 10;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        collectSound.Play();
        PlayerStatistic.Source().IncreaseScore(ScoreValue);
        Destroy(gameObject);
    }
}