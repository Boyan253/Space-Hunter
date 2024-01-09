using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondCamera;

    private bool isRightMouseButtonDown = false;

    private void Start()
    {
        // Ensure the second camera is disabled at the start
        if (secondCamera != null)
        {
            secondCamera.enabled = false;
        }
    }

    private void Update()
    {
        // Check if the right mouse button is held down
        if (Input.GetMouseButton(1))
        {
            isRightMouseButtonDown = true;
        }
        else if (isRightMouseButtonDown) // Only execute once when the button is released
        {
            SwitchCameras();
            isRightMouseButtonDown = false;
        }
    }

    public void SwitchCameras()
    {
        // Check if the main camera is currently active
        if (mainCamera.enabled)
        {
            // Disable the main camera and enable the second camera
            mainCamera.enabled = false;
            secondCamera.enabled = true;
        }
        else
        {
            // Disable the second camera and enable the main camera
            mainCamera.enabled = true;
            secondCamera.enabled = false;
        }
    }
}
