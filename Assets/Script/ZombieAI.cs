using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float attackDistance = 2f;
    public int hp = 3;

    private Animator animator;
    private bool attacking = false;
    private bool dead = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 死亡後は何もしない
        if (dead) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackDistance)
        {
            attacking = false;

            animator.SetBool("Walking", true);

            // Y軸だけ回転
            Vector3 target = player.position;
            target.y = transform.position.y;
            transform.LookAt(target);

            // プレイヤーへ移動
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

    public void TakeDamage(int damage)
    {
        Debug.Log("Zombie Hit!");
        if (dead) return;

        hp -= damage;

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        dead = true;

        animator.SetBool("Walking", false);
        animator.ResetTrigger("Attack");
        animator.SetTrigger("Death");

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        enabled = false;

        Destroy(gameObject, 3f);
    }
}