using UnityEngine;

public class Projectile : MonoBehaviour
{

  [SerializeField] GameObject hitFXPrefab;

  void OnCollisionEnter2D(Collision2D other)
  {
    GameObject fx = Instantiate(hitFXPrefab, transform.position, Quaternion.identity);
    Destroy(fx, 2f);
    Destroy(gameObject);
  }


}
