using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private Vector2 speedX = new Vector2(1, 0);
    private Vector2 speedY = new Vector2(0, 1);
    public Rigidbody2D rd;
    void Update()
    {
        if (Input.GetKey("left"))
        {
            rd.MovePosition(rd.position - speedX * Time.deltaTime);
        }
        else if (Input.GetKey("right"))
        {
            rd.MovePosition(rd.position + speedX * Time.deltaTime);
        }
        else if (Input.GetKey("up"))
        {
            rd.MovePosition(rd.position + speedY * Time.deltaTime);
        }
        else if (Input.GetKey("down"))
        {
            rd.MovePosition(rd.position - speedY * Time.deltaTime);
        }
    }
}
