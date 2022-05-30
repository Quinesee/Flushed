using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  [SerializeField] float health = 10f;
  [SerializeField] float hurtTime = 3f;
  [SerializeField] SpriteRenderer headSprite;
  [SerializeField] SpriteRenderer bodySprite;

  float invinsibleTimer = 0f;
  float flashTimer = 0f;
  bool isHurt = false;
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

  void Update()
  {
    if (invinsibleTimer > 0)
    {
      invinsibleTimer -= Time.deltaTime;
    }
    else
    {
      isHurt = false;
    }

    if (isHurt)
    {
      StartCoroutine("FlashSprite");
    }
  }

  public void TakeDamage(float amount)
  {
    if (invinsibleTimer <= 0)
    {
      Health -= amount;
      invinsibleTimer = hurtTime;
      flashTimer = hurtTime;
      isHurt = true;
    }

  }

  void Defeated()
  {
    Debug.Log("Player Ded");
    Time.timeScale = 0f;
    // Destroy(gameObject);
  }

  IEnumerator FlashSprite()
  {
    yield return new WaitForSeconds(0.1f);
    headSprite.material.color = Color.red;
    bodySprite.material.color = Color.red;
    yield return new WaitForSeconds(0.1f);
    headSprite.material.color = Color.white;
    bodySprite.material.color = Color.white;
  }
}
