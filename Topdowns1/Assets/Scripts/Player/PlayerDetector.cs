using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public Transform player; // Referência ao transform do objeto do jogador
    public float detectionRadius = 5f; // Raio de detecção do jogador
    public float moveSpeed = 3f; // Velocidade de movimento do inimigo

    private Rigidbody rb; // Referência ao Rigidbody do inimigo

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obter a referência do Rigidbody do inimigo
        player = GameObject.FindWithTag("Player").transform; // Encontrar o objeto do jogador na cena com a tag "Player"
    }


    void FixedUpdate()
    {
        // Verifica se o jogador está dentro do raio de detecção
        if (Vector3.Distance(transform.position, player.position) < detectionRadius)
        {
            // Se o jogador estiver dentro do raio de detecção, faça o inimigo perseguir o jogador
            Vector3 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }
}