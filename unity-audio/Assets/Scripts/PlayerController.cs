using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float rotateSpeed = 6.0f;
    private float jumpSpeed = 9f;
    public float gravity = 18f;
    private Transform cam;

    Vector3 velocity;
    private Vector3 direction = Vector3.zero;
    private Vector3 startPosition;
    private bool isPaused = false;
    private bool isRunning = false;
    private bool isOnGround = false;
    private bool isFalling = false;
    private bool isJumping = false;
    private AudioManager audioManager;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = GetComponent<Transform>();
        startPosition = cam.position;
        anim = GetComponentInChildren<Animator>();

        // Find the AudioManager GameObject only once during initialization
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Check for pause input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (!isPaused)
        {
            if (controller.isGrounded)
            {
                isOnGround = true;
                isFalling = false;
                anim.SetBool("ground", true);
                anim.SetBool("falling", false);
                anim.SetBool("Run", false);

                direction = new Vector3(horizontal, 0, vertical).normalized;
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                direction = cam.right * direction.x + cam.forward * direction.z;
                direction.y = 0f;
                direction *= speed;

                if (Input.GetButtonDown("Jump"))
                {
                    isJumping = true;
                    anim.SetBool("Jump", true);
                    direction.y = jumpSpeed;
                }
                else
                {
                    isJumping = false;
                    anim.SetBool("Jump", false);
                }
            }
            else
            {
                isOnGround = false;
                isFalling = true;
                anim.SetBool("ground", false);
                anim.SetBool("falling", true);
                anim.SetBool("Run", false);

                direction = new Vector3(horizontal, direction.y, vertical);
                direction = transform.TransformDirection(direction);

                direction.x *= speed;
                direction.z *= speed;
            }

            direction.y -= gravity * Time.deltaTime;
            controller.Move(direction * Time.deltaTime);

            //if fall restart from sky
            if (cam.position.y < -20)
            {
                anim.SetBool("ground", false);
                anim.SetBool("falling", true);
                anim.SetBool("Run", false);
                cam.position = new Vector3(startPosition.x, startPosition.y + 15, startPosition.z);
            }

            if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            {
                Debug.Log("RUN ON");
                Debug.Log(vertical);
                Debug.Log(horizontal);
                anim.SetBool("Run", true);
                isRunning = true;
            }
            else
            {
                anim.SetBool("Run", false);
                isRunning = false;
            }
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the game and muffle BGM
            Time.timeScale = 0;
            audioManager.MuffleBGM();
        }
        else
        {
            // Resume the game and restore BGM
            Time.timeScale = 1;
            audioManager.RestoreBGM();
        }
    }
}