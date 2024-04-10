using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mola : MonoBehaviour
{
    private Animator anim;

    [SerializeField] float impulso;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D mola)
    {
        if(mola.gameObject.tag == "Player")
        {
            mola.gameObject.GetComponent<Rigidbody2D>()
            .AddForce(Vector2.up * impulso, ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
           
        }
    }
}
