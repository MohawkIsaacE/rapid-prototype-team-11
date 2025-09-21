using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed = 10;
    bool isSpriteFlipped = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;

        }
    }
}
