using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseView : MonoBehaviour
{
    private System.Action _hitCallback;

    public void Setup(System.Action hitCallback)
    {
        _hitCallback = hitCallback;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            _hitCallback ? .Invoke();
            Destroy(gameObject);
        }
    }
}
