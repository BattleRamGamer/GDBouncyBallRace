using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    private Transform objToFollow;

    [SerializeField]
    private Vector3 offset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (objToFollow == null)
        {
            Debug.LogError("No obj to follow defined in camera FollowPlayer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        offset.x = -objToFollow.position.x;
        transform.position = objToFollow.position + offset;
        
    }
}
