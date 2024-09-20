using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Live2D.Cubism.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 13f;
    [SerializeField] private float kbForce = 6f;
    public float kbTotalTime = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private BoxCollider2D weaponCollider;
    [SerializeField] private AudioSource walkSe;
    [SerializeField] private AudioSource jumpSe;
    
    
    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider;
    private SkillManager _skillManager;
    private Animator _animator;
    private InputSystemScript _inputSystemScript;
    private Vector2 _direction;
    private Gamepad _controller;
    private CubismRenderController _renderController;

    private bool _isAttack;
    private bool _isAttacked;
    private bool _isJumping;
    private bool _isPushing;
    
    [HideInInspector] public bool isGanbara;
    [HideInInspector] public bool isBoxCarry;
    [HideInInspector] public bool isNaka;
    [HideInInspector] public bool isEscape;
    [HideInInspector] public bool isRunning;
    [HideInInspector] public bool isFacingRight;
    [HideInInspector] public bool hasCheese;
    [HideInInspector] public bool isStopped;
    [HideInInspector] public float kbCounter;
    [HideInInspector] public bool knockFromRight;
    [HideInInspector] public bool isInvincible;
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _skillManager = GetComponent<SkillManager>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        
        _inputSystemScript = new InputSystemScript();
        _inputSystemScript.Enable();
        
        _renderController = GetComponent<CubismRenderController>();

        kbCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _controller = Gamepad.current;
        
        if (isStopped)
        {
            _controller = null;
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        
        if (_controller == null)
        {
            return;
        }
        
        var xAxis = _inputSystemScript.Player.Move.ReadValue<Vector2>().x;
        _direction = new Vector2(xAxis, 0);
        
        switch (xAxis)
        {
            case < 0:
                transform.localScale = new Vector3(-1.9f, 1.9f, 1.9f);
                isFacingRight = false;
                break;
            case > 0:
                transform.localScale = new Vector3(1.9f, 1.9f, 1.9f);
                isFacingRight = true;
                break;
        }
        

        _animator.SetBool("IsWalking", xAxis != 0);

        if (_isJumping)
        {
            _animator.SetFloat("JumpDown", _rb.velocity.y);
            
            if (_rb.velocity.y <= 0)
                _animator.SetBool("IsJumpingDown", _isJumping);
            
            if (_rb.velocity.y == 0)
            {
                _isJumping = false;
                _animator.SetBool("IsJumpingDown", _isJumping);
            }
        }
        
        
        if (_controller.crossButton.wasPressedThisFrame && IsGrounded() && 
            !_controller.rightShoulder.isPressed && !_isPushing && !isRunning)
        {
            Jump();
        }
        
        if (kbCounter <= 0)
            _rb.velocity = new Vector2(speed * _direction.x, _rb.velocity.y);
        else
        {
            _rb.velocity = knockFromRight ? new Vector2(-kbForce, kbForce) : new Vector2(kbForce, kbForce);

            kbCounter -= Time.deltaTime;
        }
        
        if (_rb.velocity.x != 0 && IsGrounded() && !walkSe.isPlaying)
        {
            walkSe.Play();
        }
        
        if (hasCheese && !isEscape)
        {
            isEscape = true;
            _animator.SetTrigger("NigeNyaito");
        }
        
        switch (_skillManager.activeSkill)
        {
            case 0:
                if(!_controller.rightShoulder.isPressed && IsGrounded() && !hasCheese)
                    ResetSkill();
                break;
            case 1:
                
                if(!_controller.rightShoulder.isPressed && IsGrounded() && !hasCheese)
                {
                    if (!isBoxCarry)
                        PushSkill();
                    else
                        CarrySkill();
                }
                break;
            case 2:
                
                if(!_controller.rightShoulder.isPressed && IsGrounded() && !hasCheese)
                    AttackSkill();
                break;
            case 3:
                
                if(!_controller.rightShoulder.isPressed && IsGrounded())
                    CrySkill();
                break;
            case 4:
                
                if(!_controller.rightShoulder.isPressed && IsGrounded())
                    EscapeSkill();
                break;
            default:
                Debug.Log("No skill selected");
                break;
        }
        
        
    }
    

    #region Movement Methods

    private void Jump()
    {
        jumpSe.Play();
        _animator.SetTrigger("Jump");
        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        if (!_isJumping)
        {
            _isJumping = true;
        }
    }
    
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 
            0f, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    #endregion

    public void ResetSkill()
    {
        isGanbara = false;
        isNaka = false;
    }
    
    private void PushSkill()
    {
        var squareButton = _controller.squareButton.isPressed;
        _animator.SetBool("Push", squareButton);
        _isPushing = squareButton;
        if (squareButton)
        {
            
            isGanbara = true;
            isNaka = false;
        }
        else
        {
            isGanbara = false;
            isNaka = false;
        }
    }
    
    private void CarrySkill()
    {
        var squareButton = _controller.squareButton.isPressed;
        _animator.SetBool("Carry", squareButton);
        if (squareButton)
        {
            
            isGanbara = true;
            isNaka = false;
            
        }
        else
        {
            isGanbara = false;
            isNaka = false;
        }
    }


    private void AttackSkill()
    {
        var squareButton = _controller.squareButton.isPressed;
        weaponCollider.enabled = squareButton;
        
        if (_controller.squareButton.wasPressedThisFrame)
            _animator.SetTrigger("Attack");
        
        isGanbara = false;
        isNaka = false;
        
    }
    
    private void EscapeSkill()
    {
        var squareButton = _controller.squareButton.isPressed;
        isRunning = squareButton;
        isGanbara = false;
        isNaka = false;
        speed = 8f;
        _animator.SetBool("Run", squareButton);
    }
    
    private void CrySkill()
    {
        var squareButton = _controller.squareButton.isPressed;
        _animator.SetBool("Cry", squareButton);
        if (squareButton)
        {
            isNaka = true;
            isGanbara = false;
        }
        else
        {
            isNaka = false;
            isGanbara = false;
        }
    }

    #region CheckForBox

    private void OnCollisionEnter2D(Collision2D other)
    {
        isBoxCarry = other.gameObject.CompareTag("BoxCarry");

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (isRunning)
            {
                Destroy(other.gameObject);    
            }
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        isBoxCarry = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("House"))
        {
            SceneManager.LoadScene("Scenes/Result");
        }
    }

    #endregion

    public async Task StarInvincibilityCooldown()
    {
        float invincibilityTime = 1.5f;
        float timer = 0;
        float blinkTime = 0.1f;
        
        while (timer < invincibilityTime)
        {
            isInvincible = true;
            _renderController.Opacity = 0.5f;
            await UniTask.Delay((int)(blinkTime * 1000));
            _renderController.Opacity = 1f;
            await UniTask.Delay((int)(blinkTime * 1000));
            timer += blinkTime * 2;
        }
        
        isInvincible = false;
        
    }
}
