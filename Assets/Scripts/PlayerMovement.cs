using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    private Rigidbody2D rb2d;
    private PlayerManager playerManager;
    private PlayerAnimator playerAnim;
    
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerManager = GetComponent<PlayerManager>();
        playerAnim = GetComponent<PlayerAnimator>();

    }
    
    void FixedUpdate()
    {
        Vector2 currentPosition = rb2d.position;
        Vector2 inputVector = playerManager.GetMovementInputVector();
        Vector2 movementVector = Vector2.ClampMagnitude(inputVector, 1);

        Vector2 movementAdjustedForSpeed = movementVector * movementSpeed;
        Vector2 newPosition = currentPosition + movementAdjustedForSpeed * Time.fixedDeltaTime;
        rb2d.MovePosition(newPosition);
        playerAnim.SetDirection(movementAdjustedForSpeed);
    }
}
