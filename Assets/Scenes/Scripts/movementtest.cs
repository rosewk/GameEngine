using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementtest : MonoBehaviour
{
    private Vector2 speedX = new Vector2(1, 0);
    private Vector2 speedY = new Vector2(0, 1);
    public Rigidbody2D rb2D;
    public LayerMask whatStopMovement;
    public Transform movePoint;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            RaycastHit2D hitleft = Physics2D.Raycast(rb2D.position, Vector2.left, 1f, whatStopMovement);
            if (!hitleft.collider)
            {

                rb2D.MovePosition(rb2D.position - speedX);

            }
            
        }
        else if (Input.GetKeyDown("right"))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            RaycastHit2D hitright = Physics2D.Raycast(rb2D.position, Vector2.right, 1f, whatStopMovement);
            if (!hitright.collider)
            {
                rb2D.MovePosition(rb2D.position + speedX);
            }

        }
        else if (Input.GetKeyDown("up"))
        {
            RaycastHit2D hitCeil = Physics2D.Raycast(rb2D.position, Vector2.up, 1f, whatStopMovement);
            if (!hitCeil.collider)
            {
                rb2D.MovePosition(rb2D.position + speedY);
            }

        }
        else if (Input.GetKeyDown("down"))
        {
            RaycastHit2D hitBot = Physics2D.Raycast(rb2D.position, Vector2.down, 1f, whatStopMovement);
            if (!hitBot.collider)
            {
                rb2D.MovePosition(rb2D.position + -speedY);
            }

        }
    }
}
