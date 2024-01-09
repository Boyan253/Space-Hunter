using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
public Camera playerCamera;
   private bool isAiming = false;
    public float defaultFOV = 60f;
    public float aimingFOV = 35f;
    public CharacterController controller;
    public float speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
 private Animator animator;
    
     public AudioClip footStepSound;
     public float footStepDelay;
 
     private float nextFootstep = 0;
 
    // Update is called once per frame
    void Start(){
          animator = GetComponent<Animator>();
            playerCamera = GetComponentInChildren<Camera>();
    }
    //Roll movement(Animations)
 
      public void RollSound()
    {
        // Implement the sound logic here
    }
      public void CantRotate()
    {
        // Implement logic for when the 'CantRotate' AnimationEvent is triggered
        // For example, you might want to disable the character's ability to rotate during the animation.
    }
      public void EndRoll()
    {
        // Implement logic for when the 'CantRotate' AnimationEvent is triggered
        // For example, you might want to disable the character's ability to rotate during the animation.
    }
 void Update()
{
    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    if (isGrounded && velocity.y < 0)
    {
        velocity.y = -2f;
    }

    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    Vector3 motion = transform.right * x + transform.forward * z;
    controller.Move(motion * speed * Time.deltaTime);

    if (Input.GetButtonDown("Jump") && isGrounded)
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    velocity.y += gravity * Time.deltaTime;
    controller.Move(velocity * Time.deltaTime);

    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) && isGrounded)
    {
        nextFootstep -= Time.deltaTime;
        if (nextFootstep <= 0)
        {
            GetComponent<AudioSource>().PlayOneShot(footStepSound, 0.7f);
            nextFootstep += footStepDelay;
        }
    }
  if(Input.GetKey(KeyCode.X)){
 animator.SetTrigger("Roll");
         }
      if (Input.GetMouseButtonDown(1))
        {
            isAiming = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isAiming = false;
        }

        // Handle aiming
        if (isAiming)
        {
            animator.SetBool("Aiming", true);
            playerCamera.fieldOfView = aimingFOV; // Adjust FOV for aiming
        }
        else
        {
            animator.SetBool("Aiming", false);
            playerCamera.fieldOfView = defaultFOV; // Reset FOV when not aiming
        }
}

}


