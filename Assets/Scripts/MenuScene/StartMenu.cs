using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MenuScene
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField] private GameObject scoreText;

        public void LoadLevel(int levelNum)
        {
            SceneManager.LoadScene(levelNum);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        public void Start()
        {
            scoreText.GetComponent<Text>().text += PlayerStatistic.Source().Scores;
        }
    }
}