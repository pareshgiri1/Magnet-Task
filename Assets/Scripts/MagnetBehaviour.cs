using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MagnetBehaviour : MonoBehaviour
{
    public Canvas PickUpMessage;
    public GameObject magnetPosition;
    bool magnetWithPlayer;
    Rigidbody2D magnetRigidBody;
    public GameObject redMagnet;
    public GameObject blueMagnet;
    bool activated;
    bool IsRed = true;
    float restartTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        magnetRigidBody = GetComponent<Rigidbody2D>();
        blueMagnet.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //PickUpMessage.gameObject.SetActive(true);
        Vector3 distance = PlayerBehaviour.instance.transform.position - transform.position;
        //if(Vector2.Distance(PlayerBehaviour.instance.transform.position , transform.position) <= 1)

        // for when see message of pick up magnet
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

        // For Drop and pick up magnet
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (distance.magnitude < 3f && magnetWithPlayer == false)
            {
                MagnetPickup();
                activated = true;
            }
            else
            {
               
                ThrowTheMagnet();
            }
        }
        // For Change Magnet Polarity
        if(Input.GetKeyDown(KeyCode.F) && activated)
        {
            if(IsRed)
            {
                blueMagnet.gameObject.SetActive(true);
                redMagnet.gameObject.SetActive(false);
                IsRed = false;
            }
            else
            {
                blueMagnet.gameObject.SetActive(false);
                redMagnet.gameObject.SetActive(true);
                IsRed = true;
            }
            
        }
        // for the restart
        if(Input.GetKey(KeyCode.LeftControl))
        {
            restartTime -= Time.deltaTime;
            //Debug.Log(restartTime);
            if(restartTime <=0)
            {
                SceneManager.LoadScene(0);
                restartTime = 1;
            }
        }


    }   
       
    
    void MagnetPickup()
    {
        // Destroy(magnetRigidBody);
        magnetRigidBody.isKinematic = true;
        magnetRigidBody.simulated = false;
        transform.SetParent(magnetPosition.transform);
        // transform.localPosition = new Vector2(0, 0.5f);
        transform.position = magnetPosition.transform.position;
        PickUpMessage.gameObject.SetActive(false);
        magnetWithPlayer = true;
    }
    void ThrowTheMagnet()
    {
        transform.parent = null;
        //magnetRigidBody =  gameObject.AddComponent<Rigidbody2D>()  ;
        magnetRigidBody.isKinematic = false;
        magnetRigidBody.simulated = true;
        magnetRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation ;
        magnetRigidBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        PickUpMessage.gameObject.SetActive(true);
        magnetWithPlayer = false;
    }
}
