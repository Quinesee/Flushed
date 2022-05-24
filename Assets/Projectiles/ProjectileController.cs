using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileController : MonoBehaviour
{

  [SerializeField] GameObject projectilePrefab;
  [SerializeField] float fireForce = 4f;
  [SerializeField] float rateOfShot = 3f;
  [SerializeField] Vector3 positionOffset = new Vector3(0, 0.05f, 0);
  [SerializeField] SpriteRenderer headSprite;
  [SerializeField] List<Sprite> headSprites = new List<Sprite>();

  Vector2 fireVector = Vector2.zero;
  float shotTimer = 0f;
  Rigidbody2D rb2D;

  void Start()
  {
    rb2D = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    if (fireVector != Vector2.zero)
    {
      if (shotTimer <= 0)
      {
        shotTimer = rateOfShot;

        Shoot();
      }
    }
    shotTimer -= Time.deltaTime;
  }

  void OnShoot(InputValue fireValue)
  {
    fireVector = fireValue.Get<Vector2>();
  }

  void Shoot()
  {
    Vector2 direction = GetShootDirection();

    UpdateHeadSprite(direction);

    GameObject projectile = Instantiate(projectilePrefab, rb2D.transform.position + positionOffset, Quaternion.identity);
    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
    rb.AddForce(direction * fireForce, ForceMode2D.Impulse);
    Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), rb2D.GetComponent<Collider2D>());
  }

  Vector2 GetShootDirection()
  {
    if (fireVector.x > 0)
    {
      return Vector2.right;
    }
    else if (fireVector.x < 0)
    {
      return Vector2.left;
    }
    else if (fireVector.y > 0)
    {
      return Vector2.up;
    }
    else if (fireVector.y < 0)
    {
      return Vector2.down;
    }

    return Vector2.zero;
  }

  void UpdateHeadSprite(Vector2 direction)
  {
    if (direction.x > 0)
    {
      headSprite.sprite = headSprites[0];
    }
    else if (direction.x < 0)
    {
      headSprite.sprite = headSprites[1];
    }
    else if (direction.y > 0)
    {
      headSprite.sprite = headSprites[2];
    }
    else if (direction.y < 0)
    {
      headSprite.sprite = headSprites[3];
    }
    else
    {
      headSprite.sprite = headSprites[3];
    }
  }
}
