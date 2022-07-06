using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManagement : MonoBehaviour
{
    public GameObject redSwitch;
    public GameObject greenSwitch;
    // Start is called before the first frame update
    public Rigidbody2D obstracle1;
    public Rigidbody2D obstracle2;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        redSwitch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("GreenSwitch"))
        {
            obstracle1.gravityScale = -5;
            obstracle2.gravityScale = -5;
            greenSwitch.gameObject.SetActive(false);
            redSwitch.gameObject.SetActive(true);
        }
        if (collision.collider.CompareTag("RedSwitch"))
        {
            obstracle1.gravityScale = 5;
            obstracle2.gravityScale = 5;
            greenSwitch.gameObject.SetActive(true);
            redSwitch.gameObject.SetActive(false);
        }
    }
}
