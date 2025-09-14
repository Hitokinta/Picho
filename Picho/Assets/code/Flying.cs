using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public bool chase = false;
    public Transform startingPoint;
    private GameObject player;
    public int damageAmount = 10; // Новая переменная для урона

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player == null)
            return;

        if (chase == true)
            Chase();
        else
            ReturnStartPoint(); //go to starting position

        Flip();
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
   if (Vector2.Distance(transform.position, player.transform.position) <= 3f)
   {
 animator.SetBool("atk", true);
   }
   else
   {
   
 animator.SetBool("atk", false);
   }
        if (Vector2.Distance(transform.position, player.transform.position) <= 1.4f)
          {
        

        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
         
            playerHealth.TakeHit(damageAmount);
        }
        }
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}