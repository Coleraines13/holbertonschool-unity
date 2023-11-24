using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    private float jumpSpeed = 8.0f;
    public float gravity = 9.0f;

    // Make moveDirection public so it can be accessed externally
    public Vector3 moveDirection = Vector3.zero;

    private Vector3 startPosition;
    private Transform player;

    public CharacterController playermao;
    private Animator animator;

    // the boolean variables
    private bool onGround;
    private bool isFalling;
    private bool isRunning;

    private void Start()
    {
        playermao = GetComponent<CharacterController>();
        player = GetComponent<Transform>();
        startPosition = new Vector3(player.position.x, 0, player.position.z); // Set the initial y-coordinate to 0

        // this grabs the Animator component
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // this checks if the player is on the ground
        onGround = playermao.isGrounded;

        // this sets animation parameters based on boolean variables
        animator.SetBool("OnGround", onGround);
        animator.SetBool("IsFalling", isFalling);
        animator.SetBool("IsRunning", isRunning);

        if (onGround)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            // this will apply run multiplier if the player is holding the "Run" key
            isRunning = Input.GetKey(KeyCode.LeftShift);

            if (isRunning)
            {
                moveDirection *= speed * 1.5f; // this adjusts the multiplier based on your games requirements
            }

            // this checks for jumping input
            if (Input.GetButtonDown("Jump"))
            {
                // Set the jump trigger
                animator.SetTrigger("Jump");
                moveDirection.y = jumpSpeed;
            }
        }
        else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= speed;
            moveDirection.z *= speed;

            // this applys gravity only when not on the ground
            moveDirection.y -= gravity * Time.deltaTime;

            // this checks if the player is falling
            isFalling = moveDirection.y < -15;
        }

        // this moves the player
        playermao.Move(moveDirection * Time.deltaTime);

        // if the player falls, restart from the sky
        if (!onGround && isFalling)
        {
            player.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
        }
    }
}