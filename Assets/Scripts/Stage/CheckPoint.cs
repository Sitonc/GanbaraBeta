using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Respawn _respawn;
    private void Start()
    {
        _respawn = GameObject.FindGameObjectWithTag("Player").GetComponent<Respawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _respawn.CheckPointPos(transform.position);
        }
    }
}
