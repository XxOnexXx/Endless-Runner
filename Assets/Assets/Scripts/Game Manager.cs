using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    void Start()
    {
        Instance = this;
        Time.timeScale = 1f;
    }


    void Update()
    {

    }

    public void GameOver()
    {

        Time.timeScale = 0f;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.LogWarning("It wont work here, but it will work in build");
    }
}
