using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxHealth = 100f;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        // Input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Movement
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        if (movementDirection.magnitude > 0)
        {
            float angle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            transform.position += movementDirection * moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If colliding with enemy, reduce health
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth -= collision.gameObject.GetComponent<EnemyScript>().damageAmount;

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}