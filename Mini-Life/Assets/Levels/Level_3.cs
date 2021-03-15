using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_3 : MonoBehaviour
{
    public Text levelText;
    public int levelEnergyGoal;
    public int totalEnergyProduced = 0;

    PlayerResourcesManagement player;

    private void Start()
    {
        levelText.text = $"Energy produced: {totalEnergyProduced} / {levelEnergyGoal}";

        player = Object.FindObjectOfType<PlayerResourcesManagement>();
        player.EnergyLevelChange += Player_EnergyLevelChange;
    }

    private void Player_EnergyLevelChange(int energyAdded, int energyLevel)
    {
        if (energyAdded > 0)
        {
            totalEnergyProduced += energyAdded;
            levelText.text = $"Energy produced: {totalEnergyProduced} / {levelEnergyGoal}";

            if (totalEnergyProduced >= levelEnergyGoal)
            {
                GameManager.Instance.NextLevelMenu();
            }
        }
    }    
}
