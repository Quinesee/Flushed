using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float health = 10f;

    [SerializeField]
    float attackDist = 0.05f;

    Player player;

    AIPath aiPath;

    Rigidbody2D rb;

    SpriteRenderer spriteRenderer;

    public float Health
    {
        set
        {
            health = value;

            if (health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }

    void Awake()
    {
        aiPath = GetComponent<AIPath>();
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        aiPath.destination = player.gameObject.transform.position;
    }

    void FixedUpdate()
    {
        float dist =
            Vector2
                .Distance(player.gameObject.transform.position,
                gameObject.transform.position);

        if (dist < attackDist)
        {
            Attack();
        }
    }

    void Attack()
    {
        player.TakeDamage(1f);
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
    }

    void Defeated()
    {
        Destroy (gameObject);
    }
}
