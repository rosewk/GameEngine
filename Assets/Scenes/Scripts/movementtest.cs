using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementtest : MonoBehaviour
{
    private Vector2 speedX = new Vector2(1, 0);
    private Vector2 speedY = new Vector2(0, 1);
    public Rigidbody2D rb2D;
    public LayerMask whatStopMovement;
    public GameObject barrel;
    public GameObject barrel1;
    public GameObject barrel2;
    private Animator anim;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        barrel = GameObject.FindGameObjectWithTag("breakable");
        barrel1 = GameObject.FindGameObjectWithTag("breakable1");
        barrel2 = GameObject.FindGameObjectWithTag("breakable2");
        anim = GetComponent<Animator>();
        

    }

    IEnumerator ExampleCoroutine()
    {
     
        yield return new WaitForSeconds(1);
        anim.SetBool("isBreaking", false);
    }

    IEnumerator secondCoroutine(GameObject item)
    {

        anim.SetBool("isBreaking", true);
        yield return new WaitForSeconds(1);
        Destroy(item);
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
                print("walk left");
     
            }

            else if(hitleft.collider)
            {
                print("hit left collider");
                destroyBarrel(hitleft.collider);

            }
            
        }
        else if (Input.GetKeyDown("right"))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            RaycastHit2D hitright = Physics2D.Raycast(rb2D.position, Vector2.right, 1f, whatStopMovement);
            if (!hitright.collider)
            {
                rb2D.MovePosition(rb2D.position + speedX);
                print("walk right");
            }
            else if (hitright.collider)
            {
                print("hit right collider");
                destroyBarrel(hitright.collider);

            }
           
        }
        else if (Input.GetKeyDown("up"))
        {
            RaycastHit2D hitCeil = Physics2D.Raycast(rb2D.position, Vector2.up, 1f, whatStopMovement);
            if (!hitCeil.collider)
            {
                rb2D.MovePosition(rb2D.position + speedY);
                print("walk up");
            }
            else if (hitCeil.collider)
            {
                print("hit ceiling collider");
                destroyBarrel(hitCeil.collider);

            }

        }
        else if (Input.GetKeyDown("down"))
        {
            RaycastHit2D hitBot = Physics2D.Raycast(rb2D.position, Vector2.down, 1f, whatStopMovement);
            if (!hitBot.collider)
            {
                rb2D.MovePosition(rb2D.position + -speedY);
                print("walk down");
            }
            else if (hitBot.collider)
            {
                print("hit bottom collider");
                destroyBarrel(hitBot.collider);

            }
        }
    }

    private void destroyBarrel(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("breakable"))
        {
            StartCoroutine(secondCoroutine(barrel));
           
        }
        else if (collision.gameObject.CompareTag("breakable1"))
        {
            StartCoroutine(secondCoroutine(barrel1));
           
        }
        else if (collision.gameObject.CompareTag("breakable2"))
        {
            StartCoroutine(secondCoroutine(barrel2));
            
        }
        StartCoroutine(ExampleCoroutine());

    }

}
