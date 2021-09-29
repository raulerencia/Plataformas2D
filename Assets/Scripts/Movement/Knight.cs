using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{

    private Rigidbody2D rb;

    private float horizontal;
    private float vertical;
    public bool isGrounded;
    public float jumpForce;
    public KeyCode jump;
    private Animator anim;

    public float runSpeed = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
        //isGrounded = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        //vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {

        //rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
       
        if ( horizontal != 0){

            rb. velocity = new Vector2(horizontal * runSpeed, 0);
            transform.localScale = new Vector3(horizontal * 2,transform.localScale.y,transform.localScale.z);
            anim.SetBool("walk", true);

        }else if (Input.GetKey(jump) && isGrounded) {

            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            //rb.velocity = new Vector2(/*rb.velocity.x*/0,jumpForce);
            anim.SetBool("jump", true);

        }else{

            rb.velocity = new Vector2(0, 0);
            anim.SetBool("walk", false);

        }
    
    }

    private void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.tag.Equals("Ground")){
            anim.SetBool("jump", false);
        }

    }

    
}
