using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatCai : MonoBehaviour
{

    private Animator anim;
    private TargetJoint2D target;

    public float time;
    public float destroy;

  
    void Start()
    {      
        target = GetComponent<TargetJoint2D>();
        anim = GetComponent<Animator>();
    }

   

    void OnCollisionEnter2D(Collision2D toq)
    {
      
        if (toq.gameObject.tag == "Player")
        {
            anim.SetBool("Cai", true);
            Invoke("Falling", time);
            Destroy(this.gameObject, destroy);

            
        }


    }
    void Falling()
    {
        target.enabled = false;
    }

   




}
