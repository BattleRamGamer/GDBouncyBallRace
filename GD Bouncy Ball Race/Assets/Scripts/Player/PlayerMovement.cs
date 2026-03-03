using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float moveForce;

    private Vector3 desiredMovement;

    private Vector2 _moveInput;

    private bool isDead;


    private void Update()
    {
        
        CheckControls();

    }

    private void FixedUpdate()
    {
        // Stop movement if the player is dead
        if (isDead) return;
        ApplyMovement();
    }


    private void CheckControls()
    {

        _moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();

        desiredMovement.x = _moveInput.x;
        desiredMovement.z = _moveInput.y;

    }


    private void ApplyMovement()
    {

        rb.AddForce(desiredMovement * moveForce * Time.fixedDeltaTime);
    }

    public void Die()
    {
        isDead = true;
    }


}
