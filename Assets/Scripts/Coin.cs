using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Coin : MonoBehaviour
{

    public static int coinCount;
    public bool hasWon = false;
    private Text coinCountText;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    private void Start()
    {
       
        coinCountText = GameObject.Find("coinCountText").GetComponent<Text>();
        coinCountText.text = "Boxes: " + coinCount;
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Scene wherearewe = SceneManager.GetActiveScene();

        if (wherearewe.name == "demoscene")
        {
            coinCount = 7;
        }
        else if (wherearewe.name == "lvtwo")
        {
            coinCount = 8;
        }
        else if (wherearewe.name == "lvthree")
        {
            coinCount = 10;
        }
    }

    


    private void Update()
    {
        if (Input.GetKey("escape"))
        { Application.Quit(); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Scene wherearewe = SceneManager.GetActiveScene();
        if (collision.gameObject.tag == "Player")
        {
            playerMovement tobechecked = collision.gameObject.GetComponent<playerMovement>();
            if (tobechecked.isDashing)
            {
                coinCount--;
                coinCountText.text = "Boxes: " + coinCount;
                spriteRenderer.enabled = false;
                boxCollider2D.enabled = false;
                if (coinCount <= 0)
                {
                    if (wherearewe.name == "demoscene")
                    {
                        coinCount = 8;
                        SceneManager.LoadScene(1);
                        
                    }
                    else if (wherearewe.name == "lvtwo")
                    {
                        coinCount = 10;
                        SceneManager.LoadScene(2);
                    }
                    else if (wherearewe.name == "lvthree")
                    {
                        coinCountText.text = "VICTORY: \nPress Escape!!";
                        hasWon = true;
                    }
                }
            }
        }
    }
}

//using unityengine.scenemanager

    //scenemanager.loadscene("name of scene")

/*static int coinCount = 0;


    private Text coinCountText;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        coinCountText = GameObject.Find("CoinCountText").GetComponent<Text>();
        coinCountText.text = "Coin Count: " + coinCount;
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            coinCount++;
            coinCountText.text = "Coin Count: " + coinCount;
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            //Destroy(gameObject);
        }
    }*/
