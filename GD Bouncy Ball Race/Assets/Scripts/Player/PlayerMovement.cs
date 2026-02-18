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


    private void Update()
    {
        
        CheckControls();





    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }


    private void CheckControls()
    {

        //desiredMovement.x = Input.GetAxisRaw("horizontal");

        _moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();

        desiredMovement.x = _moveInput.x;
        desiredMovement.z = _moveInput.y;

    }


    private void ApplyMovement()
    {

        rb.AddForce(desiredMovement * moveForce * Time.fixedDeltaTime);
    }



}
