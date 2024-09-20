using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCheese : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private PlayerBehaviour _playerBehaviour;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerBehaviour = player.GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (_playerBehaviour.hasCheese)
        // {
        //     transform.position = new Vector3(player.transform.position.x,
        //         player.transform.position.y + 1f, player.transform.position.z);
        // }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && player.GetComponent<SkillManager>().activeSkill == 4)
        {
            _playerBehaviour.hasCheese = true;
            Destroy(gameObject);
        }
    }
}
