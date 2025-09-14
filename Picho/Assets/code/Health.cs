using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    
    public int health;
    public int maxHealth;

    private bool isBlocking = false;

    private void Update()
    {
        // Проверка, что кнопка L зажата
        if (Input.GetKey(KeyCode.L))
        {
            StartCoroutine(BlockDamage()); // Запуск корутины блокировки
        }

        // Проверка, что кнопка L отпущена
        if (Input.GetKeyUp(KeyCode.L))
        {
            isBlocking = false; // Отключение блокировки при отпускании кнопки
        }
    }

    private IEnumerator BlockDamage()
    {
        isBlocking = true;

        // Ждем, пока кнопка L будет отпущена
        while (Input.GetKey(KeyCode.L))
        {
            yield return null;
        }

        isBlocking = false;
    }

    public void TakeHit(int damage)
    {
        if (!isBlocking) // Проверка, активирована ли блокировка
        {
            health -= damage;

            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}