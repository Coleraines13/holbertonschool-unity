using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text timerText;
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Timer>().enabled = false;
        timerText.fontSize = 36;
        timerText.color = Color.green;
    }
}