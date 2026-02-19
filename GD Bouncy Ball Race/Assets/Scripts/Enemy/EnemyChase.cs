using UnityEngine;

public class EnemyChase : MonoBehaviour
{


    [SerializeField] 
    private float minMoveSpeed;

    [SerializeField] 
    private float maxMoveSpeed;

    [SerializeField]
    private float minMoveSpeedDistance;

    [SerializeField] 
    private float maxMoveSpeedDistance;


    [Header("Ignore")]

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Transform player;

    [SerializeField]
    bool isMoving;



    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;

        }
    }




    private void FixedUpdate()
    {
        if (isMoving)
        {
            float heightDiff = player.position.y - transform.position.y;

            float dist = Vector3.Magnitude(player.position - transform.position);

            if (dist < minMoveSpeedDistance)
            {
                moveSpeed = minMoveSpeed;
            }
            else if (dist > maxMoveSpeedDistance)
            {
                moveSpeed = maxMoveSpeed;
            }
            else
            {
                float percent = (dist - minMoveSpeedDistance) / (maxMoveSpeedDistance - minMoveSpeedDistance);
                moveSpeed = (maxMoveSpeed-minMoveSpeed) * percent + minMoveSpeed;
            }


            transform.position += moveSpeed * Vector3.forward * Time.fixedDeltaTime + Vector3.up * heightDiff;
        }
    }

    public void StartChase()
    {
        isMoving = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance?.TriggerDeath();
            Debug.Log("Player died!");
            
        }
    }

}
