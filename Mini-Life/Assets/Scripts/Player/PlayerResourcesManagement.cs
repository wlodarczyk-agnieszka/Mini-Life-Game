using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourcesManagement : MonoBehaviour
{
    public delegate void OnFoodlevelChange(int foodAdded, int foodLevel);
    public event OnFoodlevelChange FoodLevelChange;

    public delegate void OnEnergylevelChange(int energyAdded, int energyLevel);
    public event OnEnergylevelChange EnergyLevelChange;

    [Header("Food & Processing")]
    public int foodLevel;
    public int energyLevel;
    public float foodProcessingWaitSeconds = 0.2f;

    [Header("Max levels")]
    public int maxFoodLevel = 100;
    public int maxEnergyLevel = 100;

    [Header("Sounds")]
    public AudioClip eatSound;
    public AudioClip damageSound;


    private Coroutine lightRoutine = null;

    private void Awake()
    {
        AddFoodLevel(0);
        AddEnergyLevel(0);
    }
    private void Start()
    {
        //AddFoodLevel(0);
        //AddEnergyLevel(0);

        GetComponent<PlayerMovement>().PlayerUseEnergy += PlayerResourcesManagement_PlayerUseEnergy;
    }

    private void PlayerResourcesManagement_PlayerUseEnergy()
    {
        AddEnergyLevel(-1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"ENTER Trigger Collision with {other.gameObject.name}");

        if (other.gameObject.CompareTag("Food"))
        {
            AudioSource.PlayClipAtPoint(eatSound, transform.position);

            int foodValue = other.gameObject.GetComponent<Food>().foodValue;
            AddFoodLevel(foodValue);
            other.gameObject.SetActive(false);            
        }

        if (other.gameObject.CompareTag("Light"))
        {
            lightRoutine = StartCoroutine(ProcessFood());
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            AudioSource.PlayClipAtPoint(damageSound, transform.position);

            int energyValue = other.gameObject.GetComponent<Enemy>().damageValue;
            AddEnergyLevel(-energyValue);            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log($"EXIT Trigger Collision with {other.gameObject.name}");
        if (other.gameObject.CompareTag("Light"))
        {
            StopCoroutine(lightRoutine);
        }
    }

    private void AddFoodLevel(int foodValue)
    {
        foodLevel = Mathf.Clamp(foodLevel + foodValue, 0, maxFoodLevel);

        if (FoodLevelChange != null)
        {
            FoodLevelChange.Invoke(foodValue, foodLevel);
        }
    }

    private void AddEnergyLevel(int energyValue)
    {
        energyLevel = Mathf.Clamp(energyLevel + energyValue, 0, maxEnergyLevel);

        if (EnergyLevelChange != null)
        {
            EnergyLevelChange.Invoke(energyValue, energyLevel);
        }
    }

    IEnumerator ProcessFood()
    {
        while (foodLevel > 0 && energyLevel < 100)
        {
            yield return new WaitForSeconds(foodProcessingWaitSeconds);
            AddFoodLevel(-1);
            AddEnergyLevel(1);
        }
    }
}
