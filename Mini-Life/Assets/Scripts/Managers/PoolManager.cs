using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    #region Singleton
    public static PoolManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    [Header("Food")]
    public List<GameObject> foodPrefabs = new List<GameObject>();
    public int foodPoolAmount;

    [Header("Enemies")]
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public int enemyPoolAmount;

    [Header("Light")]
    public GameObject lightPrefab;

    private List<GameObject> foodPool = new List<GameObject>();
    private List<GameObject> enemyPool = new List<GameObject>();
    private GameObject light;

    void Start()
    {
        PopulateFoodPool();
        PopulateEnemyPool();
        InstantiateLight();
    }

    private void PopulateFoodPool()
    {
        int index = 0;

        for (int i = 0; i < foodPoolAmount; i++)
        {
            if(index == foodPrefabs.Count)
            {
                index = 0;
            }

            GameObject item = Instantiate(foodPrefabs[index]);
            item.SetActive(false);
            foodPool.Add(item);
            index++;
        }
    }

    private void PopulateEnemyPool()
    {
        int index = 0;

        for (int i = 0; i < enemyPoolAmount; i++)
        {
            if (index == enemyPrefabs.Count)
            {
                index = 0;
            }

            GameObject item = Instantiate(enemyPrefabs[index]);
            item.SetActive(false);
            enemyPool.Add(item);
            index++;
        }
    }

    private void InstantiateLight()
    {
        light = Instantiate(lightPrefab);
        light.SetActive(false);
    }

    public GameObject GetRandomFood()
    {
        foreach (var item in foodPool)
        {
            if (!item.activeInHierarchy)
            {
                return item;
            }
        }

        GameObject obj = Instantiate(foodPrefabs[Random.Range(0, foodPrefabs.Count)]);
        obj.SetActive(false);
        foodPool.Add(obj);

        return obj;
    }

    public GameObject GetRandomEnemy()
    {
        foreach (var item in enemyPool)
        {
            if (!item.activeInHierarchy)
            {
                return item;
            }
        }

        GameObject obj = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)]);
        obj.SetActive(false);
        enemyPool.Add(obj);

        return obj;
    }

    public GameObject GetLight()
    {
        return light;
    }
}
