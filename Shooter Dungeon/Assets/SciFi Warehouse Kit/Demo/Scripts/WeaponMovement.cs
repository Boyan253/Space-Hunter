using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the movement speed
    public float maxX = 5f; // Adjust this to set the maximum x-axis position
    public float minX = -5f; // Adjust this to set the minimum x-axis position

    void Update()
    {
        // Get the horizontal input from the player
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the new position based on the input and speed
        float newPosition = transform.position.x + horizontalInput * moveSpeed * Time.deltaTime;

        // Clamp the new position to stay within the defined range
        newPosition = Mathf.Clamp(newPosition, minX, maxX);

        // Update the weapon's position
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
    }
}
