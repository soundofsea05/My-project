using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    void Update()
    {
        if (player == null) return;

        transform.LookAt(player);

        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }
}