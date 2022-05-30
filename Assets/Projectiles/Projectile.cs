using UnityEngine;

public class Projectile : MonoBehaviour
{

  [SerializeField] GameObject hitFXPrefab;

  AudioSource audioSource;
  SpriteRenderer spriteRenderer;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  void OnCollisionEnter2D(Collision2D other)
  {

    audioSource.Play();
    spriteRenderer.enabled = false;

    if (other.gameObject.tag == "Enemy")
    {
      other.gameObject.GetComponent<Enemy>().TakeDamage(5);
    }
    GameObject fx = Instantiate(hitFXPrefab, transform.position, Quaternion.identity);
    Destroy(fx, 1f);
    Destroy(gameObject, 0.4f);
  }


}
