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
        float angle = Random.Range(0f, 360f);

        Vector3 spawnPos =
            player.position +
            new Vector3(
                Mathf.Cos(angle * Mathf.Deg2Rad) * spawnRadius,
                0,
                Mathf.Sin(angle * Mathf.Deg2Rad) * spawnRadius
            );

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