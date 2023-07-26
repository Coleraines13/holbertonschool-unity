using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutsceneController : MonoBehaviour
{
    public CinemachineFreeLook[] cameras;

    public CinemachineFreeLook CutsceneCamera;
    public CinemachineFreeLook EndingCam;

    public CinemachineFreeLook startCamera;
    private CinemachineFreeLook currentCam;

    // Start is called before the first frame update
    private void Start()
    {
        currentCam = startCamera;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] == currentCam)
            {
                cameras[i].Priority = 20;
            }
            else
            {
                cameras[i].Priority = 10;
            }
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
