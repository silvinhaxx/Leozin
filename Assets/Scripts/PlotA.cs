using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlotA : MonoBehaviour
{
    public Transform PonT;
    public Transform PontB;
    public float speed;

    private Vector3 targetPosition;


    private void Start()
    {
        targetPosition = PontB.position;
        transform.position = targetPosition;
       
    }
    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, targetPosition);

        if(distance < 0.01)
        {
            if (targetPosition == PontB.position)
            {
                targetPosition = PonT.position;
            }
            else
            {
                targetPosition = PontB.position;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }



}

