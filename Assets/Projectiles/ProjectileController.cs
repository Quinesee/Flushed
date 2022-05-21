using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileController : MonoBehaviour
{

  [SerializeField] GameObject projectilePrefab;
  [SerializeField] float fireForce = 4f;

  Vector2 fireVector = Vector2.zero;

  void OnLook(InputValue fireValue)
  {
    fireVector = fireValue.Get<Vector2>();
    Shoot();
  }

  void Shoot()
  {
    GameObject projectile = Instantiate(projectilePrefab, transform.position * 2f, Quaternion.identity);
    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
    rb.AddForce(fireVector * fireForce, ForceMode2D.Impulse);
  }
}
