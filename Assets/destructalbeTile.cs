using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class destructalbeTile : MonoBehaviour
{
    public Tilemap destructableTile;
    // Start is called before the first frame update
    private void Start()
    {
        destructableTile = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Vector3 hitPosition = Vector3.zero;
            foreach(ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                destructableTile.SetTile(destructableTile.WorldToCell(hitPosition), null);
            }
        }
    }
}
