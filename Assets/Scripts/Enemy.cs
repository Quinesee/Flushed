using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField]
  int health = 10;

  [SerializeField]
  float attackDist = 0.05f;

  GameManager gm;

  Player player;

  AIPath aiPath;

  Rigidbody2D rb;

  SpriteRenderer spriteRenderer;

  public int Health
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
    gm = FindObjectOfType<GameManager>();
    player = FindObjectOfType<Player>();
    rb = GetComponent<Rigidbody2D>();
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
    player.TakeDamage(1);
  }

  public void TakeDamage(int amount)
  {
    Health -= amount;
  }

  void Defeated()
  {
    gm.Score += 1;
    Destroy(gameObject);
  }
}
