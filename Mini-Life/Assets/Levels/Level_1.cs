using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_1 : MonoBehaviour
{
    public Text totalFood;
    public int levelFoodGoal;
    public int totalFoodEaten = 0;

    [SerializeField] GameObject welcomeMenu;
    PlayerResourcesManagement player;

    private void Start()
    {
        Time.timeScale = 0;
        welcomeMenu.SetActive(true);

        totalFood.text = $"Total Food: {totalFoodEaten} / {levelFoodGoal}";

        player = Object.FindObjectOfType<PlayerResourcesManagement>();
        player.FoodLevelChange += Player_PlayerEatEvent;
    }

    private void Player_PlayerEatEvent(int value, int foodLevel)
    {
        if (value > 0)
        {
            totalFoodEaten += value;
            totalFood.text = $"Total Food: {totalFoodEaten} / {levelFoodGoal}";

            if (totalFoodEaten >= levelFoodGoal)
            {
                GameManager.Instance.NextLevelMenu();
            }
        }
    }

    public void OkButtonClick()
    {
        welcomeMenu.SetActive(false);
        Time.timeScale = 1;
    }

}
