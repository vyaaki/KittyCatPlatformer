using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverPanel;
    public static GameOverMenu Instance { get; private set; }

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (gameOverPanel.activeInHierarchy && Input.GetKeyDown(KeyCode.Return)) RestartGame();
    }

    public void showGameOverMenu()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}