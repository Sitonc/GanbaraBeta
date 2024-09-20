using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCheese : MonoBehaviour
{
    [SerializeField] private UICheese uiCheese;
    [SerializeField] private int cheeseNumber;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (cheeseNumber)
            {
                case 1:
                {
                    uiCheese.getCheese1 = true;
                    Destroy(gameObject);
                    break;
                }
                case 2:
                {
                    uiCheese.getCheese2 = true;
                    Destroy(gameObject);
                    break;
                }
                case 3:
                {
                    uiCheese.getCheese3 = true;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
