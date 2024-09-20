using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyHP_Manager : MonoBehaviour
{
    public int _enemyHP;

    void Start()
    {
        _enemyHP = 3;
    }
    
    void Update()
    {
        if (_enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            
            _enemyHP--;
            Debug.Log("trigger" + _enemyHP);
        }
    }
}
