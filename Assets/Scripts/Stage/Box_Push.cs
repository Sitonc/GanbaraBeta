using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Box_Push : MonoBehaviour
{
    // private bool isBox;
    // private bool isWall;
    private Rigidbody2D _mRigidbody;
    static bool isBox_Push;
    void Start()
    {
        _mRigidbody = GetComponent<Rigidbody2D>();
    }

    /*void Update()
    {
        FindObjectOfType<PlayerSkill>();
        if (PlayerSkill.isGannbara && isBox && !isWall)
        {
            m_rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            m_rigidbody.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isWall = true;
        }
    }*/
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && 
            collision.gameObject.GetComponent<PlayerBehaviour>().isGanbara)
        {
            //Debug.Log("isBox_Push");
            //isBox = true;
            _mRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            isBox_Push = true;
        }
        else
        {
            _mRigidbody.constraints = ~RigidbodyConstraints2D.FreezePositionY;
            isBox_Push = false;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _mRigidbody.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        isBox_Push = false;
    }
}
