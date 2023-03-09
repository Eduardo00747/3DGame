using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do personagem.

    private Rigidbody rb; // Referência ao componente Rigidbody do personagem.
    private Vector3 movement; // Direção do movimento do personagem.

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obter a referência do Rigidbody do personagem.
    }

    void Update()
    {
        // Ler as entradas do jogador.
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calcular a direção do movimento do personagem.
        movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
    }

    void FixedUpdate()
    {
        // Mover o personagem de acordo com a direção do movimento.
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
