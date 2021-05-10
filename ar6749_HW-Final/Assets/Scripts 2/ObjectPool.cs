using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    //Stack for holding old GameObjects
    //LIFO - Last In First Out
    protected Stack<GameObject> pool = new Stack<GameObject>();

    //Get a GameObject
    public GameObject Get()
    {
        GameObject result; // var for GameObject

        if (pool.Count == 0) //if the pool is empty
        {
            result = GetNewObject(); //create a new object
            Debug.Log("hello");
        } else { //otherwise
            result = pool.Pop(); //get the top object out of the stack
            //print the total number of objects and items in the pool
            print("Num Objects:  "  + transform.childCount + " Pool Size: " + pool.Count);
        }

        result.transform.parent = this.transform; //parent the object under the GameObject w/ the Pool

        result.SetActive(true); //turn object on
        return result; //return the object
    }

    //abstract function, all children must implement this or be subclasses
    protected abstract GameObject GetNewObject();

    //Put a GameObject into the pool
    public void Push(GameObject used){
        used.SetActive(false); //turn off the GameObject
        pool.Push(used); //put it on top of the stack to be reused
    }

}

