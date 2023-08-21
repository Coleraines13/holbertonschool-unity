using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playsounds : MonoBehaviour
{
    public AudioSource MenuSFX;
    public AudioClip hoverSound;
    public AudioClip clickSound;


    public void HoverSound() {
        MenuSFX.PlayOneShot(hoverSound);
    }
    public void ClickSound() {
        MenuSFX.PlayOneShot(clickSound);
    }
 
}
