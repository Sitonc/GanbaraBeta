using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour_test : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 13f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private WeaponView weaponView;
    [SerializeField] private Transform weaponTransform;
    
    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider;
    private SkillManager_test _skillManager;
    private Animator _animator;
    private InputSystemScript _inputSystemScript;
    private Vector2 _direction;
    private Gamepad _controller;

    private bool _isAttack;
    private bool _isAttacked;
    
    [HideInInspector] public bool isGanbara;
    [HideInInspector] public bool isNaka;
    [HideInInspector] public bool isEscape;
    [HideInInspector] public bool hasCheese;
    
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Idle = Animator.StringToHash("Idle");


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _skillManager = GetComponent<SkillManager_test>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        
        _inputSystemScript = new InputSystemScript();
        _inputSystemScript.Enable();
        weaponView.Setup(HitEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        _controller = Gamepad.current;
        if (_controller == null)
        {
            Debug.Log("No gamepad connected");
            return;
        }
        
        var xAxis = _inputSystemScript.Player.Move.ReadValue<Vector2>().x;
        _direction = new Vector2(xAxis, 0);
        
        _animator.SetFloat(Speed, xAxis);
        if (xAxis == 0)
            _animator.SetTrigger(Idle);
            ResetAllTrigger();
       
  

        if (_controller.crossButton.wasPressedThisFrame && IsGrounded() && 
            !_controller.rightShoulder.isPressed)
            Jump();
        
        _rb.velocity = new Vector2(speed * _direction.x, _rb.velocity.y);
        
        if (_skillManager.activeSkill == 2)
            _isAttack = _controller.squareButton.isPressed;
        
        //if(_controller.squareButton.wasPressedThisFrame && !_controller.rightShoulder.isPressed && IsGrounded())
        if(!_controller.rightShoulder.isPressed && IsGrounded() && !hasCheese)
        {
            switch (_skillManager.activeSkill)
            {
                case 0:
                    ResetSkill();
                    break;
                case 1:
                    PushSkill();
                    _animator.SetTrigger("PushSkill");
                    break;
                case 2:
                    AttackSkill();
                    break;
                case 3:
                    CrySkill();
                    _animator.SetTrigger("CrySkill");
                    break;
                case 4:
                    EscapeSkill();
                    break;
                default:
                    Debug.Log("No skill selected");
                    break;
            }
        }
    }

    private void LateUpdate()
    {
        if (_isAttack && !_isAttacked)
        {
            _isAttacked = true;
            AttackASync().Forget();
        }
    }

    #region Movement Methods

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        _animator.SetTrigger("Jump");
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
        if (squareButton)
        {
            isGanbara = false;
            isNaka = false;

        }
    }
    
    private void EscapeSkill()
    {
        isGanbara = false;
        isNaka = false;

    }
    
    private void CrySkill()
    {
        var squareButton = _controller.squareButton.isPressed;
        if (squareButton)
        {
            isNaka = true;
            isGanbara = false;

            _animator.SetBool("isCrying",true);
        }
        else
        {
            isNaka = false;
            isGanbara = false;
          
            _animator.SetBool("isCrying",false);
        }
    }

    #region Attack Methods
    
    private async UniTask AttackASync()
    {
        weaponTransform.localRotation = Quaternion.Euler(0,0,-50);
        weaponView.EnableCollider(true);
        await UniTask.Delay(200);
        weaponTransform.localRotation = Quaternion.Euler(0,0,0);
        weaponView.EnableCollider(false);
        _isAttacked = false;
    }
    
    private void HitEnemy(GameObject enemy)
    {
        //enemy.GetComponent<EnemyMove>().EnemyDamage(1);
    }

    private void ResetAllTrigger()
    {
     _animator.ResetTrigger("CrySkill");
     _animator.ResetTrigger("PushSkill");
    }

    #endregion
}
