using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    [SerializeField] Image foodLevelFill;
    [SerializeField] Image energyLevelFill;

    [SerializeField] GameObject gameOverMenuObject;
    [SerializeField] GameObject levelCompletedMenuObject;

    [SerializeField] AudioClip gameOverSound;
    [SerializeField] AudioClip levelCompletedSound;

    private void Start()
    {
        var resourcesManager = GameObject.FindObjectOfType<PlayerResourcesManagement>();
        resourcesManager.FoodLevelChange += FoodLevelUpdate;
        resourcesManager.EnergyLevelChange += EnergyLevelUpdate;
    }

    public void FoodLevelUpdate(int foodAdded, int fillLevel)
    {
        foodLevelFill.fillAmount = fillLevel * 0.01f;
    }

    public void EnergyLevelUpdate(int energyAdded, int fillLevel)
    {
        energyLevelFill.fillAmount = fillLevel * 0.01f;
    }

    public void GameOverMenu()
    {
        gameOverMenuObject.SetActive(true);
        AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
    }

    public void LevelCompletedMenu()
    {
        levelCompletedMenuObject.SetActive(true);
        AudioSource.PlayClipAtPoint(levelCompletedSound, transform.position);
    }


}
