using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    [Header("Planets")]
    [SerializeField] private Planet firstPlanet;
    [SerializeField] private Planet SecondPlanet;

    private void OnEnable()
    {
        firstPlanet.Death += OnGameOver;
        SecondPlanet.Death += OnGameOver;
    }

    private void OnGameOver()
    {
        gameOverPanel.SetActive(!gameOverPanel.activeSelf);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void Home()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}
