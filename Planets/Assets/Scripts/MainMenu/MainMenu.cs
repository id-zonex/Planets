using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Audio A;

    private void Start()
    {
        A.PlayMainTheme();

        Time.timeScale = 1;
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync("Game");
    }
}
