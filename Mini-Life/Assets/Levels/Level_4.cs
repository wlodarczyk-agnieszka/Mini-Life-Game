using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_4 : MonoBehaviour
{
    public Text levelText;
    public int levelEnergyGoal;
    public int levelFoodGoal;

    PlayerResourcesManagement player;
    int totalEnergyProduced = 0;
    int totalFoodEaten = 0;

    private void Start()
    {
        levelText.text = $"Total Food: {totalFoodEaten} / {levelFoodGoal} | Energy produced: {totalEnergyProduced} / {levelEnergyGoal}";

        player = Object.FindObjectOfType<PlayerResourcesManagement>();
        player.EnergyLevelChange += Player_EnergyLevelChange;
        player.FoodLevelChange += Player_PlayerEatEvent;
    }

    private void Player_PlayerEatEvent(int foodAdded, int foodLevel)
    {
        if (foodAdded > 0)
        {
            totalFoodEaten += foodAdded;
            levelText.text = $"Total Food: {totalFoodEaten} / {levelFoodGoal} | Energy produced: {totalEnergyProduced} / {levelEnergyGoal}";

            CheckLevelGoals();
        }
    }

    private void Player_EnergyLevelChange(int energyAdded, int energyLevel)
    {
        if (energyAdded > 0)
        {
            totalEnergyProduced += energyAdded;
            levelText.text = $"Total Food: {totalFoodEaten} / {levelFoodGoal} | Energy produced: {totalEnergyProduced} / {levelEnergyGoal}";

            CheckLevelGoals();
        }
    }

    private void CheckLevelGoals()
    {
        if(totalFoodEaten >= levelFoodGoal && totalEnergyProduced >= levelEnergyGoal)
        {
            GameManager.Instance.NextLevelMenu();
        }
    }
}
