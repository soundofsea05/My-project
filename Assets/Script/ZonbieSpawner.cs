using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject ZombiePrefab;   // ゾンビのPrefab
    public Transform Player;          // プレイヤー
    public float spawnRadius = 20f;   // 出現半径
    public float spawnInterval = 5f;  // 出現間隔

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating(nameof(SpawnZombie), 2f, spawnInterval);
    }

    void SpawnZombie()
    {
        float angle = Random.Range(0f, 360f);

        Vector3 spawnPos = Player.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * spawnRadius, 0, Mathf.Sin(angle * Mathf.Deg2Rad) * spawnRadius        );

        Instantiate(ZombiePrefab, spawnPos, Quaternion.identity);
    }
}