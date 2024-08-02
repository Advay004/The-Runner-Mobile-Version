using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour 
{
    public float initialSpeed = 25.0f;
    private float speed;
    public float speedIncreaseRate = 0.5f; // You can adjust this value to control the speed increase rate
    private PlayerControll playerControllScript;
    private float leftbound = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerControllScript = GameObject.Find("player").GetComponent<PlayerControll>();
        playerControllScript.GameOver = false;
        playerControllScript.isOnGround = true;
        speed = initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllScript.GameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            speed += speedIncreaseRate * Time.deltaTime; // Increase speed over time
        }

        if (transform.position.x < leftbound && gameObject.CompareTag("Obstacle"))
        {
            if (playerControllScript.GameOver == true)
                Destroy(gameObject);
        }
    }
}
