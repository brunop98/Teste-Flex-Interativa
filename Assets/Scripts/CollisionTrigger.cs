using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionTrigger : MonoBehaviour
{
    public UnityEvent onCollisionEnterEvent;
    [Space]
    public UnityEvent OnCollisionExitEvent;


    private void OnCollisionEnter(Collision collision)
    {
        onCollisionEnterEvent.Invoke();
    }

    private void OnCollisionExit(Collision collision)
    {
        OnCollisionExitEvent.Invoke();
    }

}
