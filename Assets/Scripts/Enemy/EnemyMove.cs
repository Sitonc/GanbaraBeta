using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private LayerMask playerLayer;
    
    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rb;
    private Animator _animator;
    private RaycastHit2D _hitLeft;
    private RaycastHit2D _hitRight;
        
    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _hitLeft = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size,
            0f, Vector2.left, 5f, playerLayer);
        
        _hitRight = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size,
            0f, Vector2.right, 5f, playerLayer);

        if (_hitLeft.collider)
        {
            _rb.velocity = Vector2.left * speed;
            transform.localScale = new Vector3(2, 2, 2);
        }
        else if (_hitRight.collider)
        {
            _rb.velocity = Vector2.right * speed;
            transform.localScale = new Vector3(-2, 2, 2);
        }
        
        _animator.SetBool("IsWalking", _rb.velocity != Vector2.zero);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<PlayerBehaviour>();
            if (!player.isInvincible)
            {
                player.kbCounter = player.kbTotalTime;
                if (_hitLeft.collider)
                    player.knockFromRight = true;
                else if (_hitRight.collider)
                    player.knockFromRight = false;
            }
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<PlayerBehaviour>();
            if (!player.isInvincible)
            {
                player.kbCounter = player.kbTotalTime;
                if (_hitLeft.collider)
                    player.knockFromRight = true;
                else if (_hitRight.collider)
                    player.knockFromRight = false;
            }
        }
    }
}
