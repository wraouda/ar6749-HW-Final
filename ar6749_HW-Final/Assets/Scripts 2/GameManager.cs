using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private float timer = 0; // initial timer

    public GameObject enemy; // enemy object
    private float randx; // random x
    private float randy; // rrandom y
    private Vector2 where2spawn; // spawn generator
    public float spawnRate = 2f; // spawns every 2 sec
    private float nextSpawn = 0.0f; 
    
    public static GameManager instance; //this static var will hold the Singleton

    public Text timerText; // text for the timer
    
    // Start is called before the first frame update
   public void Start()
    {
        timer = 10; // 10 second timer
    }

   public void Awake()
   {
       if (instance == null) //instance hasn't been set yet
       {
           DontDestroyOnLoad(gameObject);  //Dont Destroy this object when you load a new scene
           instance = this;  //set instance to this object
       }
       else  //if the instance is already set to an object
       {
           Destroy(gameObject); //destroy this new object, so there is only ever one
       }
   }

   // Update is called once per frame
    public void Update()
    {
        timer -= Time.deltaTime; // count the time going up 

        if (Time.time > nextSpawn) // if time is greater than next spawn (which it always is) 
        {
            nextSpawn = Time.time + spawnRate; // increase the next spawn timer, spawner less units slowly
            randx = Random.Range(-8, 8); // random x between 8 and 8
            randy = Random.Range(-8, 8); // random y between 8 and 8
            where2spawn = new Vector2(randx, randy); // random between those two
            Instantiate(enemy, where2spawn, Quaternion.identity); // spawn an enemy, randomly, with no rotation
        }

        timerText.text = "Time: " + (int) timer; // timer text
    }
}
