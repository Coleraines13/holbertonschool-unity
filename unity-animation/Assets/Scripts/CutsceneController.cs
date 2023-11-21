using UnityEngine;
using Cinemachine;
using System.Collections;

public class CutsceneController : MonoBehaviour
{
    public CinemachineFreeLook[] cameras;

    public float firstSectionTime = 5f;
    public float secondSectionTime = 5f;


    private int currentCameraIndex = 0;

    private void Start()
    {
        // Ensure all cameras are disabled except for the first one.
        for (int i = 1; i < cameras.Length; i++)
        {
            // cameras[i].gameObject.SetActive(false);
            cameras[i].Priority = -1;
        }

        StartCoroutine(StartCinematic());
    }

    IEnumerator StartCinematic(){
        cameras[0].Priority = 1;
        yield return new WaitForSeconds(firstSectionTime);
        cameras[1].Priority = 2;
        yield return new WaitForSeconds(secondSectionTime);
        cameras[2].Priority = 3;
    }

}