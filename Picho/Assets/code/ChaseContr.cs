using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseContr : MonoBehaviour
{
    public Flying[] enemyArray;
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            foreach(Flying enemy in enemyArray)
            {
                enemy.chase = true; 
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
    {
        foreach(Flying enemy in enemyArray)
        {
            enemy.chase = false;
        }
    }
        
    }
    

}
