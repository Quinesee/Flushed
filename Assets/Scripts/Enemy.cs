using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] float health = 10f;
  [SerializeField] float movementSpeed = 1f;
  [SerializeField] float collisionOffset = 0.05f;
  [SerializeField] ContactFilter2D movementFilter;

  Player player;
  Rigidbody2D rb;
  List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

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

  void Start()
  {
    player = FindObjectOfType<Player>();
    rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
    Vector2 direction = player.gameObject.transform.position - gameObject.transform.position;
    bool success = TryMove(direction);
    //if collision detected, check in x then y to slide along
    if (!success)
    {
      success = TryMove(new Vector2(direction.x, 0));

      if (!success)
      {
        success = TryMove(new Vector2(0, direction.y));
      }
    }
  }

  public void TakeDamage(float amount)
  {
    Health -= amount;
  }

  void Defeated()
  {
    Destroy(gameObject);
  }

  bool TryMove(Vector2 direction)
  {
    int count = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            movementSpeed * Time.fixedDeltaTime + collisionOffset
            );

    if (count == 0)
    {
      rb.MovePosition(rb.position + direction * movementSpeed * Time.fixedDeltaTime);
      return true;
    }
    else
    {
      return false;
    }
  }
}
