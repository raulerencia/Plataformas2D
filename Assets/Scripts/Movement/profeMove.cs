using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class profeMove : MonoBehaviour
{
    public float runSpeed = 2f;
    public float jumpForce = 10f;

    private Rigidbody2D body;
    private Animator anim;
    private float horizontal;
    private int costat;
    public GameController gc;
    //int starsCount = 0;
    //public Text contadorEstrellas;

    //public GameController gc;

    // Start is called before the first frame update
    void Start()
    {   
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        costat = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey("right"))
        {
            costat = 1;
            anim.SetBool("walk", true);
            body.velocity = new Vector2(runSpeed, body.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey("left"))
        {
            costat = -1;            
            anim.SetBool("walk", true);

            body.velocity = new Vector2(-runSpeed, body.velocity.y);
        }
        else
        {
            body.velocity = new Vector2(0, body.velocity.y);
            anim.SetBool("walk", false);            
        }

        if (Input.GetKey(KeyCode.Space) && CheckGround.isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x,jumpForce);
            anim.SetBool("jump", true);
            anim.SetBool("walk", false);
        }
        transform.localScale = new Vector3(costat * 2, 2, 2);

        //contadorEstrellas.text = starsCount + "";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            anim.SetBool("jump", false);
            
        }
        else if (collision.collider.tag == "DeadZone")
        {
            gc.gameOverBox.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        
        if(col.gameObject.tag.Equals("Star")){
            Destroy(col.gameObject);
            //starsCount++;
            gc.sumar();
        }

    }
}

