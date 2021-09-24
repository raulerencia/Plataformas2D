using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{

    private Rigidbody2D body;

    private float horizontal;
    private float vertical;

    public float runSpeed = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    
    }
}
