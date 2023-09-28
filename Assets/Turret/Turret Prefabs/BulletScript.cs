using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float destroyDelay = 2f;
    public float pushForce = 50f;
    public int damage = 10; // Damage dealt by the bullet

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Call the TakeDamage method on the instance of PlayerHealth
            }

            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                Vector3 pushDirection = (other.transform.position - transform.position).normalized;
                playerRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }

            Destroy(gameObject, destroyDelay);
        }
    }
}
