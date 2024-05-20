using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;
    private int score = 0;
    private int health = 5;
    private Rigidbody playerBody;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerBody.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }

        if (other.tag == "Trap")
        {
            health--;
            Debug.Log("Health: " + health);
        }

        if (other.tag == "Goal")
        {
            Debug.Log("You win!");
        }

        if (other.tag == "Teleporter")
        {
            Debug.Log("Teleporte player");
        }
    }

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
