using UnityEngine;

public class Projectile : MonoBehaviour
{

  [SerializeField] GameObject hitFXPrefab;

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Enemy")
    {
      other.gameObject.GetComponent<Enemy>().TakeDamage(5f);
    }

    GameObject fx = Instantiate(hitFXPrefab, transform.position, Quaternion.identity);
    Destroy(fx, 1f);
    Destroy(gameObject);
  }


}
