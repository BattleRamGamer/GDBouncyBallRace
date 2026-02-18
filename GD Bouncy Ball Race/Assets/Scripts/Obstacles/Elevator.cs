using UnityEngine;

public class Elevator : MonoBehaviour
{


    [SerializeField]
    private float riseSpeed;



    [SerializeField]
    private float height;


    [SerializeField]
    private Rigidbody rb;


    [SerializeField]
    private bool isGoingUp;



    private void FixedUpdate()
    {
        if (isGoingUp)
        {
            if (transform.position.y < height)
            {
                rb.MovePosition(transform.position + Vector3.up * riseSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            if (transform.position.y > 0)
            {
                rb.MovePosition(transform.position + Vector3.down * riseSpeed * Time.fixedDeltaTime);
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartRising();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StopRising();
        }
    }

    private void StartRising()
    {
        isGoingUp = true;
    }

    private void StopRising()
    {
        isGoingUp = false;
    }



}
