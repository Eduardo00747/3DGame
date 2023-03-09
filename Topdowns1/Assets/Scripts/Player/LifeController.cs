using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public int maxHealth = 100; // Vida máxima do personagem.
    public int currentHealth; // Vida atual do personagem.

    void Start()
    {
        currentHealth = maxHealth; // Inicializa a vida atual com a vida máxima.
    }

    void OnCollisionEnter(Collision collision)
    {
        // Se o objeto colidido for um inimigo, diminua a vida do personagem.
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("O personagem colidiu com o inimigo!");

            // Diminua a vida do personagem.
            currentHealth -= 10;

            // Se a vida do personagem chegar a zero, destrua o objeto.
            if (currentHealth <= 0)
            {
                Debug.Log("O personagem morreu!");
                Destroy(gameObject);
            }
        }
    }
}


