using UnityEngine;
using System;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    public UnityEvent OnPinFall = new();
    public bool isPinFallen = false;
    private void OnTriggerEnter(Collider triggeredObject)
    {
        //add if to check is fall to ground and already falled
        if (triggeredObject.CompareTag("Ground") && !isPinFallen)
        {
            isPinFallen = true;
            //this will bound event to object
            OnPinFall?.Invoke();
            Debug.Log($"{gameObject.name} is fallen");
        }
    }
}
