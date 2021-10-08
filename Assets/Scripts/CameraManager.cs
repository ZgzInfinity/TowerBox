
/*
 * ------------------------------------------
 * -- Project: Tower Box --------------------
 * -- Author: Rubén Rodríguez Estebban ------
 * -- Date: 8/10/2021 -----------------------
 * ------------------------------------------
 */

using UnityEngine;

/**
 * Script that controls the movement of the camera
 */

public class CameraManager : MonoBehaviour
{
    // Static instance
    public static CameraManager Instance;

    // Reference to the position of the box spawner
    public Transform boxSpawner;

    // Shake effec duration
    public float shakeDuration = 0.25f;

    // Shaking intensity
    public float shakeAmount = 0.15f;

    // Decreasing factor of the shaking effect
    public float decreaseFactor = 1.0f;

    // Scroll speed of the camera
    public float scrollSpeed = 2.5f;

    // Controls if the camera is shaking
    private bool shaking;

    // Position of the camera before shaking
    private Vector3 preShakePosition;

    // Time that the camera is shaking
    private float shakeTimer;

    // Hightest position of the top box
    private float highestBoxPosition = -5f;

    // Initial position of the camera
    private Vector3 initialPosition;

    // Controls if the screen is scrolling
    private bool scrolling; 

    // Constructor
    private void Awake()
    {
        Instance = this;
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the game is active
        if (GameManager.Instance.isGameActive)
        {
            // Check if the screen is shaking
            if (shaking)
            {
                // Continue shaking
                CheckShakeEffect();
            }
            // Check the position of the camera while is shaking
            CheckCameraPosition();
        }
        else
        {
            // Check if the camera is scrolling
            if (scrolling)
            {
                // Continue with the scroll
                ScrollCamera();
            }
        }
    }

    // Check the position of the camera
    private void CheckCameraPosition()
    {
        // Check if the camera has to scroll up
        if (highestBoxPosition + 6f > boxSpawner.position.y)
        {
            // Camera scrolls up to see the last box
            transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
        }
    }

    // Check the shake effect
    private void CheckShakeEffect()
    {
        // Check if the shaking effect has finished
        if (shakeTimer > 0)
        {
            // Move the camera in a random direction and decrease the shaking time
            transform.localPosition = preShakePosition + Random.insideUnitSphere * shakeAmount;
            shakeTimer -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            // Shaking effect finished
            shaking = false;
            shakeTimer = 0f;

            // Camera recovers the the initial position
            transform.localPosition = preShakePosition;
        }
    }

    // Make the sake effect
    public void Shake()
    {
        // Start shaking
        shaking = true;
        preShakePosition = transform.localPosition;
        shakeTimer = Random.Range(shakeDuration - 0.10f, shakeDuration + 0.10f);
    }

    // Update the height with the highest box
    public void UpdateBoxesHeight(float boxHeight)
    {
        // Check if the highest box has been reached
        if (boxHeight > highestBoxPosition)
        {
            // Updates the height
            highestBoxPosition = boxHeight;
        }
    }
        
    // Scroll the camera
    private void ScrollCamera()
    {
        // Move the camera down to the initial position
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, 0.15f);

        // Check if the camera is on the initial position
        if (transform.position == initialPosition)
        {
            // Finish scroll
            scrolling = false;
        }
    }

    // Reset the camera position
    public void ResetCameraPosition()
    {
        // Start the scrolling down
        scrolling = true;
    }
 }
