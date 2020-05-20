using UnityConstants;
using UnityEngine;

public class FinishLevelEvent : MonoBehaviour
{
    [SerializeField] private GameObject finishPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Tags.Player))
        {
            PlayerStatistic.Source().IncreaseTotalScore();
            finishPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}