using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int maxHealth = 50; // Vida máxima do inimigo.
    public int currentHealth; // Vida atual do inimigo.

    void Start()
    {
        currentHealth = maxHealth; // Inicializa a vida atual com a vida máxima.
    }

    void OnCollisionEnter(Collision collision)
    {
        // Se o objeto colidido for o jogador, diminua a vida do inimigo.
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("O inimigo foi atingido!");

            // Diminua a vida do inimigo.
            currentHealth -= 10;

            // Se a vida do inimigo chegar a zero, destrua o objeto.
            if (currentHealth <= 0)
            {
                Debug.Log("O inimigo foi derrotado!");
                Destroy(gameObject);
            }
        }
    }
}
