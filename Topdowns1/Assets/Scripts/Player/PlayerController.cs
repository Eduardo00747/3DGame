using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do personagem.

    private Rigidbody rb; // Refer�ncia ao componente Rigidbody do personagem.
    private Vector3 movement; // Dire��o do movimento do personagem.

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obter a refer�ncia do Rigidbody do personagem.
    }

    void Update()
    {
        // Ler as entradas do jogador.
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calcular a dire��o do movimento do personagem.
        movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
    }

    void FixedUpdate()
    {
        // Mover o personagem de acordo com a dire��o do movimento.
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Se o objeto colidido for um inimigo, destru�-lo.
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Debug.Log("O personagem colidiu com o inimigo!");
            //Destroy(collision.gameObject);
        }


    }
}