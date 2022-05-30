using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  [SerializeField] int health = 10;
  [SerializeField] float hurtTime = 3f;
  [SerializeField] SpriteRenderer headSprite;
  [SerializeField] SpriteRenderer bodySprite;

  [SerializeField] HealthBar healthBar;

  float invinsibleTimer = 0f;
  float flashTimer = 0f;
  bool isHurt = false;
  GameManager gm;

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

  void Start()
  {
    gm = FindObjectOfType<GameManager>();
    healthBar.SetMaxHealth(Health);
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

  public void TakeDamage(int amount)
  {
    if (invinsibleTimer <= 0)
    {
      Health -= amount;
      invinsibleTimer = hurtTime;
      flashTimer = hurtTime;
      isHurt = true;
      healthBar.SetHealth(Health);
    }

  }

  void Defeated()
  {
    gm.PauseGame();
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
