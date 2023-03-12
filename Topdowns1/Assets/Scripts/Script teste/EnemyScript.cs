using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRange = 10f;
    public float maxHealth = 50f;
    public float damageAmount = 10f;
    public float pushBackForce = 100f;

    private float currentHealth;
    private Transform player;
    private bool isFollowingPlayer = false;

    private void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Check if player is within detection range
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < detectionRange)
        {
            isFollowingPlayer = true;
        }

        // Move towards player if following
        if (isFollowingPlayer)
        {
            transform.LookAt(player);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If colliding with player, reduce health and push player back
        if (collision.gameObject.CompareTag("Player"))
        {
            currentHealth -= damageAmount;

            Vector3 pushDirection = (collision.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(pushDirection * pushBackForce);

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

