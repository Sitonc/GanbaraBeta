using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UnseenFloor : MonoBehaviour
{
    [SerializeField] private GameObject floor;
    //private bool isUnseenFloor;


    // void Update()
    // {
    //     FindObjectOfType<PlayerSkill>();
    //     if (PlayerSkill.isNaka && isUnseenFloor)
    //     {
    //         Debug.Log("isBlossom");
    //         floor.SetActive(true);
    //     }
    // }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")
            && collision.gameObject.GetComponent<PlayerBehaviour>().isNaka)
        {
            //Debug.Log("isFlower");
            floor.SetActive(true);
        }
    }
    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         isUnseenFloor = false;
    //     }
    // }
}
