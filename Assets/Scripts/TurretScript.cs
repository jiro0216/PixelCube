//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class TurretScript : MonoBehaviour
//{
//    //public NavMeshAgent enemy;
//    public Transform player;

//    public GameObject enemyBullet;
//    public Transform spawnPoint;
//    public float enemySpeed;

//    [SerializeField] private float timer = 5f;
//    private float bulletTime;

//    // Euler angles for debugging
//    float y, x, z;
//    public Vector3 currentEulerAngles;
//    Quaternion currentRotation;



//    // Start is called before the first frame update
//    void Start()
//    {
//        bulletTime = timer; // Initialize the bulletTime
//        currentRotation = transform.rotation; // Initialize currentRotation
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Handle rotation based on player input (X, Y, Z keys)
//        //RotateInput();

//        // You can choose one of the rotation methods below, comment out the others if not needed
//        //QuaternionRotateTowards(); // Rotates towards a specific target (targetA)
//        //SlerpExample();

//        // Look at a specific target (targetA)
//        LookRotation();

//        // Set the destination of the enemy to the player's position
//        //player.SetDestination(player.position);

//        // Shoot at the player

//        ShootAtPlayer();
//    }

//    void ShootAtPlayer()
//    {
//        // Decrease the bulletTime each frame
//        bulletTime -= Time.deltaTime;

//        // Check if it's time to shoot
//        if (bulletTime <= 0)
//        {
//            // Reset the bulletTime
//            bulletTime = timer;

//            // Calculate the direction from the turret to the player
//            Vector3 shootDirection = (player.position - spawnPoint.position).normalized;

//            // Instantiate an enemy bullet at the spawn point
//            GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.position, Quaternion.identity);

//            // Access the Rigidbody component of the bullet
//            Rigidbody bulletRigidbody = bulletObj.GetComponent<Rigidbody>();

//            // Check if the Rigidbody component exists
//            if (bulletRigidbody != null)
//            {
//                // Apply an initial velocity in the direction of the player
//                bulletRigidbody.velocity = shootDirection * enemySpeed;

//                // Apply recoil force in the opposite direction
//                float recoilForce = 5f; // Adjust the strength of the recoil as needed
//                bulletRigidbody.AddForce(-shootDirection * recoilForce, ForceMode.Impulse);
//            }

//            Destroy(bulletObj, 5f);
//        }
//    }





//    //void RotateInput()
//    //{
//    //    currentRotation.eulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotSpeed;
//    //    currentEulerAngles = currentRotation.eulerAngles; // Update currentEulerAngles
//    //    transform.rotation = currentRotation;
//    //}

//    //void QuaternionRotateTowards()
//    //{
//    //    float step = rotSpeed * Time.deltaTime;
//    //    transform.rotation = Quaternion.RotateTowards(transform.rotation, player.rotation, step);
//    //}

//    void LookRotation()
//    {
//        Vector3 relativePos = player.position - transform.position;
//        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
//        transform.rotation = rotation; // Apply the calculated rotation to the object
//    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform player;
    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float bulletSpeed;
    public float shootingRadius = 10f; // Adjust this radius as needed.
    public float rotationSpeed = 60f; // Adjust the rotation speed as needed.

    [SerializeField] private float timer = 5f;
    private float bulletTime;

    private bool isPlayerInRange = false; // Track if the player is in range

    void Start()
    {
        bulletTime = timer;
    }

    void Update()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the shooting range
        if (distanceToPlayer <= shootingRadius)
        {
            isPlayerInRange = true;
            RotateTowardsPlayer();
        } else
        {
            isPlayerInRange = false;
        }

        if (isPlayerInRange)
        {
            ShootAtPlayer();
        }
    }

    void OnDrawGizmos()
    {
        // Only draw Gizmos when the player is in range
        if (isPlayerInRange)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, shootingRadius);
        }
    }

    void ShootAtPlayer()
    {
        // Your shooting logic remains the same
        bulletTime -= Time.deltaTime;

        if (bulletTime <= 0)
        {
            bulletTime = timer;
            Vector3 shootDirection = (player.position - spawnPoint.position).normalized;
            GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.position, Quaternion.identity);
            Rigidbody bulletRigidbody = bulletObj.GetComponent<Rigidbody>();

            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = shootDirection * bulletSpeed;
                float recoilForce = 5f;
                bulletRigidbody.AddForce(-shootDirection * recoilForce, ForceMode.Impulse);
            }

            Destroy(bulletObj, 5f);
        }
    }

    void RotateTowardsPlayer()
    {
        Vector3 relativePos = player.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(relativePos, Vector3.up);
        float step = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
    }
}




