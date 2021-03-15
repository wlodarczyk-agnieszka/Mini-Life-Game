using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion


    private void Start()
    {
        var resourcesManager = GameObject.FindObjectOfType<PlayerResourcesManagement>();
        if (resourcesManager != null)
            resourcesManager.EnergyLevelChange += ResourcesManager_EnergyLevelChange;
    }

    private void ResourcesManager_EnergyLevelChange(int energyAdded, int energyLevel)
    {
        if (energyLevel <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        UIManager.Instance.GameOverMenu();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevelMenu()
    {
        Time.timeScale = 0;
        UIManager.Instance.LevelCompletedMenu();
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        // build index 0 = main menu scene
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
