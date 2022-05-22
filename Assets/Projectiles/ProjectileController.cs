using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileController : MonoBehaviour
{

  [SerializeField] GameObject projectilePrefab;
  [SerializeField] float fireForce = 4f;
  [SerializeField] float rateOfShot = 3f;

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

    GameObject projectile = Instantiate(projectilePrefab, rb2D.transform.position, Quaternion.identity);
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
}
