using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleLevelGoals : MonoBehaviour
{
    PlayerResourcesManagement player;
    public Text totalFood;
    public int levelFoodGoal;
    public int totalFoodEaten = 0;

    void Start()
    {
        totalFood.text = $"Total Food: {totalFoodEaten} / {levelFoodGoal}";

        player = Object.FindObjectOfType<PlayerResourcesManagement>();
        player.FoodLevelChange += Player_PlayerEatEvent;       
    }

    private void Player_PlayerEatEvent(int value, int foodLevel)
    {
        if(value > 0)
        {
            totalFoodEaten += value;
            totalFood.text = $"Total Food: {totalFoodEaten} / {levelFoodGoal}";

            if (totalFoodEaten >= levelFoodGoal)
            {
                GameManager.Instance.NextLevelMenu();
            }
        }
    }
}
