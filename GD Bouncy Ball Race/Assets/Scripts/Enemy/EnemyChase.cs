using UnityEngine;

public class EnemyChase : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;


    [SerializeField]
    bool isMoving;








    private void FixedUpdate()
    {
        if (isMoving)
        {
            transform.position += moveSpeed * Vector3.forward * Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance?.TriggerDeath();
            Debug.Log("Touching!");
            transform.Rotate(Vector3.up * 10);
            
        }
    }

}
