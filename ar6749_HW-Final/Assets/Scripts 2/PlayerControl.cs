using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float forceAmount = 5;

    public static PlayerControl instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb2D.AddForce(Vector2.up * forceAmount);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb2D.AddForce(Vector2.left * forceAmount);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb2D.AddForce(Vector2.down * forceAmount);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb2D.AddForce(Vector2.right * forceAmount);
        }
        
        if(Input.GetKeyDown(KeyCode.Space)){ //if you press space
            Ammunition.instance.GetBullet(); //get a bullet
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(1);
        }
    }
}