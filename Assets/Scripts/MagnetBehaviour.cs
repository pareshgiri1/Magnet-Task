using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetBehaviour : MonoBehaviour
{
    public Canvas PickUpMessage;
    public GameObject magnetPosition;
    bool magnetWithPlayer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 distance = PlayerBehaviour.instance.transform.position - transform.position;
       if(Vector2.Distance(PlayerBehaviour.instance.transform.position , transform.position) <= 1) 
        //if(distance.magnitude < 4f)
        {
            //Mathf.Abs(distance.magnitude)
            if(magnetWithPlayer == false)
            {
                PickUpMessage.gameObject.SetActive(true);
            }
            
            if (Input.GetKeyDown(KeyCode.E)  )
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
        else
        {
            PickUpMessage.gameObject.SetActive(false);
        }
       
    }
    void MagnetPickup()
    {
        transform.SetParent(magnetPosition.transform);
        transform.localPosition = new Vector2(0, 1);
        PickUpMessage.gameObject.SetActive(false);
        magnetWithPlayer = true;
    }
    void ThrowTheMagnet()
    {
        transform.parent = null;
        PickUpMessage.gameObject.SetActive(true);
        magnetWithPlayer = false;
    }
}
