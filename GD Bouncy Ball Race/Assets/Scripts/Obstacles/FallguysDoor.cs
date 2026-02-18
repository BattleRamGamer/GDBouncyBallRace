using UnityEngine;

public class FallguysDoor : MonoBehaviour
{
    [Header("Magic numbers")]
    [SerializeField]
    private float riseSpeed;



    [SerializeField] 
    private float minRandomRiseTime;

    [SerializeField] 
    private float maxRandomRiseTime;


    [Header("Ignore")]
    [SerializeField]
    private float riseTimer;

    [SerializeField]
    private bool isRaised;


    [SerializeField]
    private float depth = 3.1f;


    [SerializeField]
    private Transform door;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isRaised = Random.value < .5f ? true : false;
        ResetRiseTime();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        riseTimer -= Time.fixedDeltaTime;
        if (riseTimer <= 0) ResetRiseTime();


        if (isRaised)
        {
            if (door.position.y < 0)
            {
                float currentDoorPos = Mathf.Clamp(door.position.y + riseSpeed * Time.fixedDeltaTime, -depth, 0);
                door.position = Vector3.up * currentDoorPos + transform.position;
            }
        }
        else
        {
            if (door.position.y > -depth)
            {
                float currentDoorPos = Mathf.Clamp(door.position.y - riseSpeed * Time.fixedDeltaTime, -depth, 0);
                door.position = Vector3.up * currentDoorPos + transform.position;
            }
        }




    }

    private void ResetRiseTime()
    {
        riseTimer = Random.value * (maxRandomRiseTime - minRandomRiseTime) + minRandomRiseTime;
        isRaised = !isRaised;
    }
}
