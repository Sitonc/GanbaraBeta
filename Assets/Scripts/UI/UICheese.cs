using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UICheese : MonoBehaviour
{
    public static UICheese instance = null;

    public GameObject cheese1;
    public GameObject cheese2;
    public GameObject cheese3;

    // public int C1 = 0;
    // public int C2 = 0;
    // public int C3 = 0;

    [HideInInspector] public bool getCheese1;
    [HideInInspector] public bool getCheese2;
    [HideInInspector] public bool getCheese3;

    void Start()
    {
        
    }

    void Update()
    {
        GetCheesePieces();
    }

    private void GetCheesePieces()
    {
        /*if(C1 == 1)
        {
            cheese1.SetActive(false);
        }
        if(C2 == 1)
        {
            cheese2.SetActive(false);
        }
        if(C3 == 1)
        {
            cheese3.SetActive(false);
        }*/
        
        cheese1.SetActive(!getCheese1);
        cheese2.SetActive(!getCheese2);
        cheese3.SetActive(!getCheese3);
    }
}
