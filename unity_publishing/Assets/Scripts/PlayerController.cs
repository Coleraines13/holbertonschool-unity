using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class PlayerController : MonoBehaviour
{
    public Text healthText;
    public Text scoreText ;
    public float speed = 1000f;
    public Rigidbody rb;
    private int score = 0;
    public int health = 5;
    public Image winLoseBG;
    public Text winLoseText;


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pickup")
        {
            score++;
            SetScoreText();
            Destroy(other.gameObject);
        }

        if(other.tag == "Trap")
        {
            health--;
            SetHealthText();
        }

        if(other.tag == "Goal")
        {
            congratsTextField();
            StartCoroutine(LoadScene(3));
        }
    }
    void SetScoreText(){
        scoreText.text = $"Score: {this.score}";
    }
    
    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }


    //Displays congrats message oin the text field
    void congratsTextField()
    {
        winLoseBG.color = new Color32(0, 255, 0, 255);
        winLoseText.color = new Color32(0, 0, 0, 255);
        winLoseText.text = "You win!";
        winLoseBG.gameObject.SetActive(true);
    }

    //displays your failure
    void appologyMessageTextField()
    {
        winLoseBG.color = new Color32(255, 0, 0, 255);
        winLoseText.color = new Color32(0, 0, 0, 255);
        winLoseText.text = "Game over!";
        winLoseBG.gameObject.SetActive(true);
    }

    // waits before restarting the game at win or gameover
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Maze");
        score = 0;
        health = 5;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("w") || Input.GetKey("up"))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }

        if(Input.GetKey("s") || Input.GetKey("down"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }

        if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }

        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(speed * Time.deltaTime,0,0);
        }
    }
    

    void Update()
    {
        if(Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene("menu");
        }

        
        if(health == 0)
        {
        appologyMessageTextField();
        StartCoroutine(LoadScene(3));
        }
    }
}