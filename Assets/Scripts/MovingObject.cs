using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;
    private int startingPoint=0;
    public Transform[] points;

    private int i;
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    //void Update()
    //{
    //    if (Vector2.Distance(transform.position, points[i].position) < 0.02)
    //    {
    //        i++;
    //        if(i == points.Length)
    //        {
    //            i = 0;
    //        }
    //    }
    //    transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    //    transform.Rotate(0, 0, 22.5f);
    //}

   void Update()
    {
        if (Vector2.Distance(points[startingPoint].transform.position, transform.position) < 0.1f) 
        {
            startingPoint++;
            if(startingPoint>=points.Length)
            {
                startingPoint = 0;
            }
        }
        transform.position=Vector2.MoveTowards(transform.position, points[startingPoint].transform.position, speed*Time.deltaTime);
        transform.Rotate(0, 0, 22.5f);
    }


}
