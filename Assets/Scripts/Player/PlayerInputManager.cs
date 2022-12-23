using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyUp(KeyCode.E) && DialogSystem.instance.DialogIsWaitingToPlay())
        {
            DialogSystem.instance.DisplayDialog();
        }
    }

    public Vector2 GetMovementInputVector()
    {
        return new Vector2(horizontalInput, verticalInput);
    }
}
