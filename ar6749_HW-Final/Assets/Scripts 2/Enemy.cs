using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;

    private Rigidbody2D rb2d;

    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position; // calculate the distance between the two players

        direction.Normalize();
        movement = direction; 

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb2d.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime)); // follow the player 
    }

}
