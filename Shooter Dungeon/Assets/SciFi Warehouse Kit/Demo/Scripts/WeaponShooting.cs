using UnityEngine;

public class FPS_Shooting : MonoBehaviour
{
    public Transform gunTransform;       // Transform of the gun object.
    public GameObject bulletPrefab;      // The projectile or bullet prefab.
    public Transform bulletSpawnPoint;   // Transform representing the position where bullets will be spawned.
    public float bulletForce = 20f;      // The force applied to the bullet when shooting.
    public Transform enemyTarget;        // The transform of the enemy target.

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to the appropriate input button
        {
            Shoot();
        }
    }

  void Shoot()
{
    // Get the forward direction of the camera
    Vector3 shootDirection = Camera.main.transform.forward;

    // Create a ray starting from the camera position in the shootDirection
    Ray ray = new Ray(Camera.main.transform.position, shootDirection);

    // Check if the ray hits something
    RaycastHit hitInfo;

    if (Physics.Raycast(ray, out hitInfo))
    {
        // Get the GameObject that was hit
        GameObject hitObject = hitInfo.collider.gameObject;

        // Do something based on the hit object
        Debug.Log("Hit object: " + hitObject.name);

        // If the hit object has an EnemyHealth script, apply damage
        EnemyHealth enemyHealth = hitObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(20); // Adjust the damage value as needed
        }
    }

    // Create a new bullet at the bulletSpawnPoint position and rotation
    GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.LookRotation(shootDirection));

    // Get the Rigidbody component of the bullet
    Rigidbody rb = bullet.GetComponent<Rigidbody>();

    // Apply force to the bullet in the calculated direction
    rb.AddForce(shootDirection * bulletForce, ForceMode.Impulse);

    // Debug statement to indicate that the gun was fired
    Debug.Log("Gun fired!");
}

}
