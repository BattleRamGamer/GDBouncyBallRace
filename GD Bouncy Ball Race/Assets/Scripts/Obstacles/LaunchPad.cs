using UnityEngine;

public class LaunchPad : MonoBehaviour
{


    [SerializeField]
    private float launchForce;


    [SerializeField]
    private Transform launchAngle;




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.rigidbody.AddForce(launchAngle.up * launchForce, ForceMode.VelocityChange);
        }
    }


}
