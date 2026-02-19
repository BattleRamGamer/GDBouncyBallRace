using UnityEngine;
using UnityEngine.Events;

public class EventOnTrigger : MonoBehaviour
{


    [SerializeField] private UnityEvent onCollisionEvents;




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onCollisionEvents?.Invoke();
        }
    }




}
