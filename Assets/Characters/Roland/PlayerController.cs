using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

  [SerializeField] float movementSpeed = 1f;
  [SerializeField] float collisionOffset = 0.05f;
  [SerializeField] ContactFilter2D movementFilter;

  Vector2 movementVector = Vector2.zero;
  Rigidbody2D rb;
  List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
    if (movementVector != Vector2.zero)
    {
      //try moveing in the direction
      bool success = TryMove(movementVector);

      //if collision detected, check in x then y to slide along
      if (!success)
      {
        success = TryMove(new Vector2(movementVector.x, 0));

        if (!success)
        {
          success = TryMove(new Vector2(0, movementVector.y));
        }
      }
    }
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

  void OnMove(InputValue movementValue)
  {
    movementVector = movementValue.Get<Vector2>();
  }
}
