using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playsounds : MonoBehaviour
{
    public AudioSource MenuSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playThisSoundEffect()
    {
        MenuSFX.Play();
    }
}
