using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    // Reference to other game objects
    public GameObject mainCamera;
    public GameObject playerController;
    public GameObject timerCanvas;

    // Reference to the Animator component
    private Animator cutsceneAnimator;

    private void Start()
    {
        // Get the Animator component attached to the GameObject
        cutsceneAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if the "Level01" animation has finished playing
        if (!cutsceneAnimator.GetCurrentAnimatorStateInfo(0).IsName("Level01"))
        {
            // Enable Main Camera
            if (mainCamera != null)
            {
                mainCamera.SetActive(true);
            }

            // Enable PlayerController
            if (playerController != null)
            {
                playerController.SetActive(true);
            }

            // Enable TimerCanvas
            if (timerCanvas != null)
            {
                timerCanvas.SetActive(true);
            }

            // Disable CutsceneController
            gameObject.SetActive(false);
        }
    }
}