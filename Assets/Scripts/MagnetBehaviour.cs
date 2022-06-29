using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetBehaviour : MonoBehaviour
{
    public Canvas PickUpMessage;
    public GameObject magnetPosition;
    bool magnetWithPlayer;
    Rigidbody2D magnetRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        //magnetRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //PickUpMessage.gameObject.SetActive(true);
        Vector3 distance = PlayerBehaviour.instance.transform.position - transform.position;
        //if(Vector2.Distance(PlayerBehaviour.instance.transform.position , transform.position) <= 1) 
        if (distance.magnitude < 3f && magnetWithPlayer == false)
        {
            //Mathf.Abs(distance.magnitude)

            PickUpMessage.gameObject.SetActive(true);
        }
        else
        {
            //if(magnetWithPlayer == true)
            PickUpMessage.gameObject.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (magnetWithPlayer == false)
            {
                MagnetPickup();
            }
            else
            {
               
                ThrowTheMagnet();
            }
        }


    }   
       
    
    void MagnetPickup()
    {
        Destroy(magnetRigidBody);
        transform.SetParent(magnetPosition.transform);
        transform.localPosition = new Vector2(0, 0.5f);
        PickUpMessage.gameObject.SetActive(false);
        magnetWithPlayer = true;
    }
    void ThrowTheMagnet()
    {
        transform.parent = null;
        magnetRigidBody =  gameObject.AddComponent<Rigidbody2D>()  ;
        magnetRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation ;
        magnetRigidBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        PickUpMessage.gameObject.SetActive(true);
        magnetWithPlayer = false;
    }
}
