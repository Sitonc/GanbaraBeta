using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WaterwheelForRisingPlatform : MonoBehaviour
{
    private bool isWaterwheel;
    [SerializeField] private GameObject risingPlatform;
    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // void Update()
    // {
    //     FindObjectOfType<PlayerSkill>();
    //     if (PlayerSkill.isNaka && isWaterwheel)
    //     {
    //         Debug.Log("RisingPlatform");
    //         Vector3 Pos = risingPlatform.transform.position;
    //         Pos = Vector3.MoveTowards(Pos, new Vector3(0,9,0), 2 * Time.deltaTime);
    //         risingPlatform.transform.position = Pos;
    //     }
    // }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &&
            collision.gameObject.GetComponent<PlayerBehaviour>().isNaka)
        {
            StartCoroutine(RisingPlatform());
            _animator.SetBool("WaterWheel",true);
        }
        else
        {
            _animator.SetBool("WaterWheel", false);
        }
    }
    
    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         isWaterwheel = false;
    //     }
    // }
    
    private IEnumerator RisingPlatform()
    {
        Vector3 pos = risingPlatform.transform.position;
        pos = Vector3.MoveTowards(pos, new Vector3(0,9,0), 2 * Time.deltaTime);
        risingPlatform.transform.position = pos;
        yield return null;
    }
}
