using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public float force;
    public GameObject Magnet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
      GameObject MagnetInt =   Instantiate(Magnet,transform.position,transform.rotation);
        MagnetInt.GetComponent<Rigidbody2D>().AddForce(transform.right * force);
    }

}
