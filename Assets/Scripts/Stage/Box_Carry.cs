using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Box_Carry : MonoBehaviour
{
    //private bool isBox;
    //private Rigidbody2D m_rigidbody;
    [SerializeField] private GameObject player;

    private bool _isCarried;
    static bool isBox_Carry;
    private PlayerBehaviour _playerBehaviour;
    private SkillManager _skillManager;
    private BoxCollider2D _boxCollider2D;

    void Start()
    {
        //m_rigidbody = GetComponent<Rigidbody2D>();
        _playerBehaviour = player.GetComponent<PlayerBehaviour>();
        _skillManager = player.GetComponent<SkillManager>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // FindObjectOfType<PlayerSkill>();
        // if (PlayerSkill.isGannbara && isBox)
        // {
        //     Vector2 NewPos =  new Vector2(player.transform.position.x, player.transform.position.y + 1.8f);
        //     transform.position = NewPos;
        //     transform.parent = player.transform;
        // }
        // else
        // {
        //     transform.parent = null;
        // }
        
        if (_skillManager.activeSkill == 1 && _isCarried && _playerBehaviour.isGanbara)
        {
            _boxCollider2D.isTrigger = true;
            gameObject.layer = 0;
            transform.position = new Vector3(player.transform.position.x,
                player.transform.position.y + 1f, player.transform.position.z);
        }
        else
        {
            if (_isCarried)
            {
                _isCarried = false;
                gameObject.layer = 6;
                _boxCollider2D.isTrigger = false;
                _playerBehaviour.isBoxCarry = false;
                if (_playerBehaviour.isFacingRight)
                    transform.position = new Vector3(player.transform.position.x + 2f,
                        player.transform.position.y + -.25f, player.transform.position.z);   
                else 
                    transform.position = new Vector3(player.transform.position.x - 2f,
                        player.transform.position.y + -.25f, player.transform.position.z);   
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &&
            _playerBehaviour.isGanbara && _skillManager.activeSkill == 1)
        {
            _isCarried = true;
            isBox_Carry = true;
        }
    }

     private void OnCollisionExit2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "Player")
         { 
             isBox_Carry = false;
         }
     }
}
