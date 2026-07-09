using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform player;

    public float spawnRadius = 20f;
    public float startInterval = 5f;
    public float minimumInterval = 1f;
    public float minX = -35f;
    public float maxX = 35f;
    public float minZ = -30f;
    public float maxZ = 30f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnZombie();

            yield return new WaitForSeconds(GetSpawnInterval());
        }
    }

    void SpawnZombie()
    {
        Vector3 spawnPos;

        do
        {
            spawnPos = new Vector3(
                Random.Range(minX, maxX),
                0f,
                Random.Range(minZ, maxZ)
            );
        }
        while (Vector3.Distance(spawnPos, player.position) < 8f);

        Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
    }

    float GetSpawnInterval()
    {
        int score = GameManager.Instance.score;

        float interval = startInterval - score * 0.2f;

        if (interval < minimumInterval)
            interval = minimumInterval;

        return interval;
    }
}