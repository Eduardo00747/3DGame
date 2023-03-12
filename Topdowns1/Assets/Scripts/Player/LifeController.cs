using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Importe esta biblioteca para ter acesso às funções de cena.

public class LifeController : MonoBehaviour
{
    public int maxHealth = 100; // Vida máxima do personagem.
    public int currentHealth; // Vida atual do personagem.
    public Slider healthSlider; // Referência ao objeto Slider.

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

            // Atualize o valor do Slider com a vida atual do personagem.
            healthSlider.value = (float)currentHealth / (float)maxHealth;

            // Se a vida do personagem chegar a zero, reinicie o jogo.
            if (currentHealth <= 0)
            {
                Debug.Log("O personagem morreu!");
                RestartGame(); // Chame a função RestartGame para reiniciar o jogo.
            }
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Carregue a cena atual novamente para reiniciar o jogo.
    }
}
