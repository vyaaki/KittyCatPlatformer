using UnityEngine;

public class CollectScores : MonoBehaviour
{
    public AudioSource collectSound;
    public int ScoreValue = 10;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        collectSound.Play();
        UpdateScore.ScoreCounter += ScoreValue;
        Destroy(gameObject);
    }

    private void Awake()
    {
        UpdateScore.ScoreCounter = 0;
    }
}