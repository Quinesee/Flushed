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
      int count = rb.Cast(
        movementVector,
        movementFilter,
        castCollisions,
        movementSpeed * Time.fixedDeltaTime + collisionOffset
        );

      if (count == 0)
      {
        rb.MovePosition(rb.position + movementVector * movementSpeed * Time.fixedDeltaTime);
      }
    }
  }

  void OnMove(InputValue movementValue)
  {
    movementVector = movementValue.Get<Vector2>();
  }
}
