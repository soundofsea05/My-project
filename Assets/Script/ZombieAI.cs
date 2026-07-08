using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float attackDistance = 2f;

    Animator animator;
    bool attacking = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackDistance)
        {
            attacking = false;

            animator.SetBool("Walking", true);

            Vector3 target = player.position;
            target.y = transform.position.y;
            transform.LookAt(player);

            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }
        else
        {
            animator.SetBool("Walking", false);

            if (!attacking)
            {
                attacking = true;
                animator.SetTrigger("Attack");
            }
        }
    }
}