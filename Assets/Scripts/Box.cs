
/*
 * ------------------------------------------
 * -- Project: Tower Box --------------------
 * -- Author: Rubén Rodríguez Estebban ------
 * -- Date: 8/10/2021 -----------------------
 * ------------------------------------------
 */

using UnityEngine;

/**
 * Script that controls the behaviour of the boxes
 */

public class Box : MonoBehaviour
{

    // Array with the drop sounds
    public Sound[] dropSounds;

    // Array with the hit sounds
    public Sound[] hitSounds;

    // Speed of the box when it's moved horizontally
    public float horizontalSpeed = 3f;

    // Reference to the rigidody
    private Rigidbody2D boxRigidBody2D;

    // Check if the box has collided
    [SerializeField]
    private bool hasCollided;

    // Limit points of the horizontal move
    private Vector2 pointA;
    private Vector2 pointB;

    // Reference to the transform of the ox spawner
    private Transform boxSpawner;

    // Control the direction of the horizontal movement of the box
    private bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        // Box has not collided
        hasCollided = false;

        // Reference the rigidody
        boxRigidBody2D = GetComponent<Rigidbody2D>();

        // Reference to the box spawner
        boxSpawner = CameraManager.Instance.boxSpawner;

        // Initialize the limits points of the moves
        pointA = new Vector2(-2, boxSpawner.position.y);
        pointB = new Vector2(2, boxSpawner.position.y);
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if the game is actived
        if (GameManager.Instance.isGameActive)
        {
            // Check if the box is affected by the gravity
            if (boxRigidBody2D.gravityScale == 0f)
            {
                // Move the box horizontally
                Move();
            }

            // Check if the screen is touched
            if (Input.GetMouseButtonDown(0))
            {
                // Play a dropping box sound
                AudioManager.Instance.PlaySound(dropSounds[Random.Range(0, dropSounds.Length)]);

                // The box is affected by the gravity
                boxRigidBody2D.gravityScale = 1f;
            }
        }
        else
        {
            // Check if the next box to throw has collided
            if (!hasCollided)
            {
                // The last box also falls 
                this.boxRigidBody2D.gravityScale = 1f;
            }
        }
    }

    // Move a box horizontally from right to left and viceversa
    private void Move()
    {
        // Check the current direction of the move
        if (movingRight)
        {
            // Move to the right
            transform.position = Vector2.MoveTowards(transform.position, pointB, horizontalSpeed * Time.deltaTime);
        }
        else
        {
            // Move to the left
            transform.position = Vector2.MoveTowards(transform.position, pointA, horizontalSpeed * Time.deltaTime);
        }

        // Check if the box has arrived to the limit point 
        if (transform.position.x >= pointB.x)
        {
            // Move to the right because it's on the right limit point
            movingRight = false;
        }
        else if (transform.position.x <= pointA.x)
        {
            // Move to the right because it's on the right limit point
            movingRight = true;
        }
    }

    // Sent when an incoming collider makes contact with this object's collider (2D physics only).
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the box has experimented a valid collision
        if (!hasCollided && (collision.collider.CompareTag(GameTags.Box) || collision.collider.CompareTag(GameTags.Ground)))
        {
            // Box has collided
            hasCollided = true;

            // Play a hit sound
            AudioManager.Instance.PlaySound(hitSounds[Random.Range(0, hitSounds.Length)]);

            // Make shaking camera effect
            CheckShake();

            // Update the score
            GameManager.Instance.SetScore();

            // Modify the height of the camera
            CameraManager.Instance.UpdateBoxesHeight(transform.position.y);
        }
    }

    // Sent when another object enters a trigger collider attached to this object 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the trigger object is the GameOverZone
        if (collision.CompareTag(GameTags.GameOverZone))
        {
            // Game over
            GameManager.Instance.GameOver();
        }
    }

    // Make a shaking effect in the screen
    private void CheckShake()
    {
        // Check if it's the first time
        if (GameManager.Instance.Score == 0)
        {
            // Camera shakes
            CameraManager.Instance.Shake();
        }
        else
        {
            // Probaility of the 30% to shake
            int shakeRandom = Random.Range(0, 10);

            // Higher than 70%
            if (shakeRandom > 7)
            {
                // Camera shakes
                CameraManager.Instance.Shake();
            }
        }
    }
}
