using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed = 10;
    bool isSpriteFlipped = false;
    public GameObject[] checkpoints = new GameObject[4];
    public GameObject winImage;
    int currentCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        // Reset all the game objects
        currentCheckpoint = 0;
        checkpoints[1].gameObject.SetActive(true);
        checkpoints[2].gameObject.SetActive(true);
        checkpoints[3].gameObject.SetActive(true);
        winImage.SetActive(false);

        rb.transform.position = checkpoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Gravity flipping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale *= -1;
            if (isSpriteFlipped)
            {
                GetComponent<SpriteRenderer>().flipY = false;
                isSpriteFlipped = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipY = true;
                isSpriteFlipped = true;
            }
        }

        // Movement
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;

        }

        // Reset button
        if (Input.GetKey(KeyCode.R))
        {
            Start();
        }

        // Exit button
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Spike collision
        if (collision.gameObject.tag == "spike")
        {
            rb.transform.position = checkpoints[currentCheckpoint].transform.position;
        }

        // Checkpoint collision
        if (collision.gameObject.tag == "checkpoint")
        {
            collision.gameObject.SetActive(false);
            currentCheckpoint += 1;
        }

        // Win collision
        if (collision.gameObject.tag == "win")
        {
            collision.gameObject.SetActive(false);
            winImage.SetActive(true);
        }
    }
}
