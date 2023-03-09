
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f; // Velocidade de movimento do inimigo

    private Rigidbody enemyRigidbody;
    private CapsuleCollider enemyCollider;
    private bool isMovingRight = true;
    private Vector3 moveDirection;

    private bool isPlayerDetected = false;
    private Transform playerTransform;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyCollider = GetComponent<CapsuleCollider>();
        moveDirection = isMovingRight ? Vector3.right : Vector3.left; // Começa se movendo para a direita
    }

    void FixedUpdate()
    {
        if (!isPlayerDetected)
        {
            // Se o inimigo não está perseguindo o jogador, patrulhe entre as bordas do cenário
            float xPos = enemyRigidbody.position.x + moveDirection.x * speed * Time.fixedDeltaTime;
            if (xPos + enemyCollider.radius > 10f)
            {
                xPos = 10f - enemyCollider.radius;
                moveDirection = Vector3.left;
                isMovingRight = false;
            }
            else if (xPos - enemyCollider.radius < -10f)
            {
                xPos = -10f + enemyCollider.radius;
                moveDirection = Vector3.right;
                isMovingRight = true;
            }
            enemyRigidbody.MovePosition(new Vector3(xPos, enemyRigidbody.position.y, enemyRigidbody.position.z));
        }
        else
        {
            // Se o jogador está dentro do raio de detecção, persiga-o
            Vector3 playerDirection = (playerTransform.position - transform.position).normalized;
            enemyRigidbody.MovePosition(transform.position + playerDirection * speed * Time.fixedDeltaTime);
        }
    }

    void OnColliderEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Se o jogador entrar no raio de detecção, comece a persegui-lo
            isPlayerDetected = true;
            playerTransform = other.transform;
        }
    }

}