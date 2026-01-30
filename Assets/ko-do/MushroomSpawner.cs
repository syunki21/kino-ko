using UnityEngine;
using System.Collections.Generic;

public class MushroomSpawner : MonoBehaviour
{
    [Header("キノコPrefab")]
    public GameObject[] goodMushroomPrefabs;
    public GameObject[] badMushroomPrefabs;

    [Header("生成範囲")]
    public float areaSize = 20f;
    public float minDistance = 2f;

    [Header("初期配置")]
    public int initialSpawnCount = 10;

    [Header("徐々に増える設定")]
    public int maxMushroomCount = 30;
    public float spawnInterval = 3f;

    private List<Vector3> spawnPositions = new List<Vector3>();
    private int currentCount = 0;
    private List<BadMushroom> badMushrooms = new List<BadMushroom>();

    void Start()
    {
        // ① 初期配置
        for (int i = 0; i < initialSpawnCount; i++)
        {
            SpawnOneMushroom();
        }

        // ② 時間経過で追加
        InvokeRepeating(nameof(SpawnOneMushroom), spawnInterval, spawnInterval);
    }

    void SpawnOneMushroom()
    {
        if (currentCount >= maxMushroomCount)
            return;

        int safetyCount = 0;

        while (safetyCount < 100)
        {
            safetyCount++;

            Vector3 randomPos = new Vector3(
                Random.Range(-areaSize, areaSize),
                0f,
                Random.Range(-areaSize, areaSize)
            );

            if (!IsFarEnough(randomPos))
                continue;

            bool isGood = Random.value < 0.5f;
            GameObject prefab = GetRandomMushroom(isGood);
            if (prefab == null) return;

            Quaternion rot = Quaternion.Euler(-90f, 0f, 0f);
            Instantiate(prefab, randomPos, rot);

            spawnPositions.Add(randomPos);
            currentCount++;
            break;
        }
    }

    GameObject GetRandomMushroom(bool isGood)
    {
        if (isGood)
        {
            if (goodMushroomPrefabs.Length == 0) return null;
            return goodMushroomPrefabs[Random.Range(0, goodMushroomPrefabs.Length)];
        }
        else
        {
            if (badMushroomPrefabs.Length == 0) return null;
            return badMushroomPrefabs[Random.Range(0, badMushroomPrefabs.Length)];
        }
    }

    bool IsFarEnough(Vector3 pos)
    {
        foreach (Vector3 existing in spawnPositions)
        {
            if (Vector3.Distance(pos, existing) < minDistance)
                return false;
        }
        return true;
    }
}
