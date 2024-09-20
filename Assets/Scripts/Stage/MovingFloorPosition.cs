using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloorPosition : MonoBehaviour
{
    [SerializeField] private Transform[] TargetPoint;
    private int index;
    private float WaitTime;
    void Start()
    {
        WaitTime = 1.0f;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPoint[index].position, 2 * Time.deltaTime);
        if(Vector2.Distance(transform.position, TargetPoint[index].position) < 0.1f)
        {
            if(WaitTime < 0.0f)
            {
                index++;
                if (index > TargetPoint.Length - 1)
                {
                    index = 0;
                }

                WaitTime = 1.0f;
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
            
           
        }
        
    }
}
