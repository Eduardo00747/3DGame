using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public Transform player; // Refer�ncia ao transform do objeto do jogador
    public float detectionRadius = 5f; // Raio de detec��o do jogador
    public float moveSpeed = 3f; // Velocidade de movimento do inimigo

    private Rigidbody rb; // Refer�ncia ao Rigidbody do inimigo

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obter a refer�ncia do Rigidbody do inimigo
        player = GameObject.FindWithTag("Player").transform; // Encontrar o objeto do jogador na cena com a tag "Player"
    }


    void FixedUpdate()
    {
        // Verifica se o jogador est� dentro do raio de detec��o
        if (Vector3.Distance(transform.position, player.position) < detectionRadius)
        {
            // Se o jogador estiver dentro do raio de detec��o, fa�a o inimigo perseguir o jogador
            Vector3 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }
}