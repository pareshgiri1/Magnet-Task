using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 ThrowPosotion = transform.position;

        direction = (MousePosition - ThrowPosotion) * (-1);

        FaceMouse();
    }

    void FaceMouse()
    {
        transform.up = direction;
    }
}
