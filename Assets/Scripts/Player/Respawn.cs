using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    //[SerializeField] private GameObject Cheese;
    [SerializeField] private Vector2 StartPos;
    [SerializeField] private Transform EndPos;
    public static bool isAlive;
    //private SpriteRenderer _Sp;
    private Rigidbody2D _Rb;
    [SerializeField] private Vector2 CheckPos;
    [SerializeField] private List<GameObject> Obj = new List<GameObject>();
    [SerializeField] private List<Transform> ObjPos = new List<Transform>();
    private void Start()
    {
        _Rb = GetComponent<Rigidbody2D>();
        //_Sp = GetComponent<SpriteRenderer>();
        isAlive = true;
        CheckPos = StartPos;
    }

    void FixedUpdate()
    {
        if (this.transform.position.y <= -5)
        {
            isAlive = false;
        }
        if (isAlive == false) 
        {
            die();
            isAlive = true;
        }
    }

    public void CheckPointPos (Vector2 pos)
    {
        CheckPos = pos;
    }
    private void die()
    {
        this.enabled = false;
        _Rb.bodyType = RigidbodyType2D.Static;
        StartCoroutine(DoRespawn());
    }

    IEnumerator DoRespawn()
    {
        for(int i = 0;i < Obj.Count; i++)
        {
            Obj[i].transform.position = ObjPos[i].position;
        }

        yield return new WaitForSeconds(0.5f);
       
        this.enabled = true;
        _Rb.bodyType = RigidbodyType2D.Dynamic;
        transform.position = CheckPos;
        //if (Cheese != null) 
        //{
        //    transform.position = CheckPos;      
        //}
        //else if(Cheese == null) 
        //{
        //    transform.position = EndPos.position;
        //}
    }
}