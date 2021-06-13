using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    public void ShowPausePanel(bool enabled)
    {
        pausePanel.SetActive(enabled);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public void LoadMainMenu()
    {
        ContinueGame();
        SceneManager.LoadSceneAsync("Menu");
    }
}
