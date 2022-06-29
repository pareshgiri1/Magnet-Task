using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    float force = 10000;
    public float speed = 10 ;
    bool IsGrounded = true;
    public static PlayerBehaviour instance ;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed,0);
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.gravityScale = 0;
            rb.AddForce(Vector2.up * force);
            rb.gravityScale = 50f ;
            IsGrounded = false;
        }
    }
    
    private bool OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
        return IsGrounded;
    }
}
