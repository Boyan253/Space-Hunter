using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    // Adjust this distance to control the distance from the camera
    public float distanceFromCamera = 2f;

    void Update()
    {
        // Get the camera's forward direction
        Vector3 cameraForward = Camera.main.transform.forward;

        // Set the position of the empty GameObject in front of the camera
        transform.position = Camera.main.transform.position + cameraForward * distanceFromCamera;
    }
}
