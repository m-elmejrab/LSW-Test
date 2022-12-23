using UnityEngine;

//Class is based on Unity tutorial on isometric movement adjusted for this project (https://youtu.be/tywt9tOubEY)
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private PlayerInputManager playerInputManager;
    private PlayerAnimator playerAnim;
    
    [SerializeField] private float movementSpeed = 1f;
    
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerInputManager = GetComponent<PlayerInputManager>();
        playerAnim = GetComponent<PlayerAnimator>();
    }
    
    void FixedUpdate()
    {
        Vector2 currentPosition = rb2d.position;
        Vector2 inputVector = playerInputManager.GetMovementInputVector();
        Vector2 movementVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movementAdjustedForSpeed = movementVector * movementSpeed;
        Vector2 newPosition = currentPosition + movementAdjustedForSpeed * Time.fixedDeltaTime;
        
        rb2d.MovePosition(newPosition);
        playerAnim.SetDirection(movementAdjustedForSpeed);
    }
}
