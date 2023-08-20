using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent<Collider> onEnter, onStay, onExit;
    public GameObject objectTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (objectTrigger == other.gameObject)
        {
            onEnter.Invoke(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (objectTrigger == other.gameObject)
        {
            onStay.Invoke(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectTrigger == other.gameObject)
        {
            onExit.Invoke(other);
        }
    }
}
