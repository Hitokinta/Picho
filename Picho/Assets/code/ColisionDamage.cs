using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDamage : MonoBehaviour
{

  private void Start() {
    
  }
  public int collisionDamage = 10;
  public string collisionTag;
  public void OnCollisionEnter2D(Collision2D coll) 
  {
    if (coll.gameObject.tag == collisionTag)
    {
        Health health = coll.gameObject.GetComponent<Health> ();
        health.TakeHit(collisionDamage);
    }
  }
 
    }

