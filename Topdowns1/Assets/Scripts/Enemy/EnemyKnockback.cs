using UnityEngine;
using System.Collections;

public class EnemyKnockback : MonoBehaviour
{

    public float knockbackDelay = 0.15f;  // Delay em segundos
    public float knockbackForce = 16f;   // Força do knockback

    private Rigidbody rb;
    private bool knockbackEnabled = false;
    private float knockbackTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (knockbackEnabled)
        {
            knockbackTimer += Time.deltaTime;
            if (knockbackTimer >= knockbackDelay)
            {
                knockbackEnabled = false;
                knockbackTimer = 0f;
                rb.velocity = Vector3.zero;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            knockbackEnabled = true;
            Vector3 direction = (other.transform.position - transform.position).normalized;
            rb.AddForce(-direction * knockbackForce, ForceMode.Impulse);
        }
    }
}
