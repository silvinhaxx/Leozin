using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rig;
    public float speed;

    public float jumpForce;

    public bool isJumping;
    public bool doubleJumping;

  
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
       
    }

    void Move()
    {
        rig.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rig.velocity.y);     

        if(Input.GetAxisRaw("Horizontal") > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector2(0f, 0f);
        }

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector2(0f, 180f);
        }

        if (Input.GetAxisRaw("Horizontal") == 0f)
        {
            anim.SetBool("walk", false);
            
        }

    }  

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJumping = true;
                anim.SetBool("jump", true);

            }
            else
            {
                if (doubleJumping)
                {
                    rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    doubleJumping = false;
                }

            }

        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Chao")
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
        
        if (collision.gameObject.tag == "Spike")
        {
           anim.SetBool("Dead", true);
            Destroy(this.gameObject, 0.3f);
          
        }
        else
        {
            anim.SetBool("Dead", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Chao")
        {
            isJumping = true;
        }
    }








}
