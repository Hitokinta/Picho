using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
        // Уничтожаем пулю через 5 секунд после создания
        Destroy(gameObject, 1.5f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        // Проверяем, является ли объект столкновения противником
        if (hitInfo.CompareTag("Enemy"))
        {
            // Получаем компонент EnemyHp из объекта столкновения и наносим урон
            EnemyHp enemyHp = hitInfo.GetComponent<EnemyHp>();
            if (enemyHp != null)
            {
                enemyHp.TakeDamage(damage);
            }
             Destroy(gameObject);
             

             
             
        }
        
    }
}
