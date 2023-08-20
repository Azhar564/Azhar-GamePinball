using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    public UnityEvent<Collision> onEnter, onStay, onExit;
    public GameObject objectTrigger;

    private void OnCollisionEnter(Collision other)
    {
        if (objectTrigger == other.gameObject)
        {
            onEnter.Invoke(other);
        }
    }

    private void OnCollisionStay(Collision other)
    {   
        if (objectTrigger == other.gameObject)
        {
            onEnter.Invoke(other);
        }
    }   

    private void OnCollisionExit(Collision other)
    {
        if (objectTrigger == other.gameObject)
        {
            onEnter.Invoke(other);
        }
    }
}
