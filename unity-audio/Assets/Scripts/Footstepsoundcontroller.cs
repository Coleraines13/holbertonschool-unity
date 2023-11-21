using UnityEngine;

public class Footstepsoundcontroller : MonoBehaviour
{
    public AudioClip footstepsRunningGrass; // Sound for running on grass
    public AudioClip footstepsRunningRock;  // Sound for running on rock
    public AudioSource audioSource; // Reference to the AudioSource component
    public CharacterController characterController; // Reference to the CharacterController component
    public Animator animator; // Reference to the Animator component

    private bool isGrounded = true; // Flag to track if the player is grounded

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = characterController.isGrounded;

        // Play footstep sound when the player is grounded and moving
        if (isGrounded && characterController.velocity.magnitude > 0.1f)
        {
            if (animator.GetBool("IsRunning"))
            {
                PlayFootstepSound();
            }
        }
    }

    private void PlayFootstepSound()
    {
        if (!audioSource.isPlaying)
        {
            if (animator.GetBool("IsOnGrass"))
            {
                audioSource.clip = footstepsRunningGrass;
            }
            else if (animator.GetBool("IsOnRock"))
            {
                audioSource.clip = footstepsRunningRock;
            }
            audioSource.Play();
        }
    }
}