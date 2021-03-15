using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Food")]
    public float minFoodSpawnInterval;
    public float maxFoodSpawnInterval;

    [Header("Spawn Enemies")]
    public float minEnemySpawnInterval;
    public float maxEnemySpawnInterval;

    [Header("Spawn Light")]
    public float lightTimer; // how long Light will last
    public float minLightSpawnInterval;
    public float maxLightSpawnInterval;

    void Start()
    {
        StartCoroutine(SpawnFoodRoutine());

        StartCoroutine(SpawnLightRoutine());

        StartCoroutine(SpawnEnemyRoutine());
    }

    #region Spawn Food
    IEnumerator SpawnFoodRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minFoodSpawnInterval, maxFoodSpawnInterval));
            SpawnFood();
        }
    }

    private void SpawnFood()
    {
        Vector2 position = GenerateSpawnPosition();

        var item = PoolManager.Instance.GetRandomFood();
        item.transform.position = position;
        item.SetActive(true);
    }

    #endregion

    #region Spawn light
    IEnumerator SpawnLightRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minLightSpawnInterval, maxLightSpawnInterval));
            SpawnLight();
        }
    }

    private void SpawnLight()
    {
        // determine spawn location
        float xRange = 7f;
        float y = 3.5f;
        Vector2 position = new Vector2(Random.Range(-xRange, xRange), y);

        //GameObject lightObject = Instantiate(lightPrefab, position, Quaternion.identity);
        GameObject light = PoolManager.Instance.GetLight();
        light.transform.position = position;
        light.SetActive(true);

        StartCoroutine(LightTimer(light));
    }

    IEnumerator LightTimer(GameObject light)
    {
        yield return new WaitForSeconds(lightTimer);
        light.SetActive(false);
    }
    #endregion

    #region Spawn Enemies
    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minEnemySpawnInterval, maxEnemySpawnInterval));
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector2 position = GenerateSpawnPosition();

        var item = PoolManager.Instance.GetRandomEnemy();
        item.transform.position = position;
        item.SetActive(true);
    }
    #endregion

    private Vector2 GenerateSpawnPosition()
    {
        // spawn positions
        Vector2 leftSide = new Vector2(-9f, Random.Range(-4f, 4f));
        Vector2 rightSide = new Vector2(9.5f, Random.Range(-4f, 4f));
        Vector2 topSide = new Vector2(Random.Range(-8f, 8f), 5.5f);
        Vector2 bottomSide = new Vector2(Random.Range(-8f, 8f), -5.5f);

        Vector2[] positions = new Vector2[] { leftSide, rightSide, topSide, bottomSide };

        return positions[Random.Range(0, positions.Length)];
    }
    
}
