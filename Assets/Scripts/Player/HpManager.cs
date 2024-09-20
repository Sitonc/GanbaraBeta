using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> hpImages;

    private PlayerBehaviour _playerBehaviour;
    
    private int _hp = 3;

    private void Start()
    {
        _playerBehaviour = GetComponent<PlayerBehaviour>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (!_playerBehaviour.isInvincible)
            {
                _hp--;
                hpImages[_hp].SetActive(false);
                if (_hp <= 0)
                {
                    Debug.Log("Game Over");
                }
                _playerBehaviour.StarInvincibilityCooldown();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (!_playerBehaviour.isInvincible)
            {
                _hp--;
                hpImages[_hp].SetActive(false);
                if (_hp <= 0)
                {
                    Debug.Log("Game Over");
                }
                _playerBehaviour.StarInvincibilityCooldown();
            }
        }
    }
}
