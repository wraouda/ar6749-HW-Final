using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedMod = 10; //how fast is the bullet

    const float MAX_Y = 10; //where do we recycle the bullet

    Rigidbody2D rb; //rigidBody2D holder

    private void Update()
    {
        if(transform.position.y > MAX_Y){ //if the bullet has moved to far up
            Ammunition.instance.Push(gameObject);  //return it to the pool
        }
    }

    //used to reset the bullet after you recycle it
    public void Reset()
    {
        if(rb == null){ //if rb is not set
            rb = GetComponent<Rigidbody2D>(); //set it
        }
        rb.velocity = Vector2.up * speedMod; //reset it's speed

        //reset it's position to above the ship
         transform.position = new Vector2(
            PlayerControl.instance.transform.position.x,
            PlayerControl.instance.transform.position.y + 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            GameManager.
            Destroy(collision.gameObject);
            
        }
    }
}
