using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public static CameraManager Instance;

    public Transform boxSpawner;

    public float shakeDuration = 0.25f;
    public float shakeAmount = 0.15f;
    public float decreaseFactor = 1.0f;
    public float scrollSpeed = 2.5f;

    private bool shaking;
    private Vector3 preShakePosition;
    private float shakeTimer;
    private float highestBoxPosition = -5f;
    private Vector3 initialPosition;
    private bool scrolling; 

    private void Awake()
    {
        Instance = this;
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameActive)
        {
            if (shaking)
            {
                CheckShakeEffect();
            }
            CheckCameraPosition();
        }
        else
        {
            if (scrolling)
            {
                scrollCamera();
            }
        }
    }

    private void CheckCameraPosition()
    {
        if (highestBoxPosition + 6f > boxSpawner.position.y)
        {
            transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
        }
    }

    private void CheckShakeEffect()
    {
        if (shakeTimer > 0)
        {
            transform.localPosition = preShakePosition + Random.insideUnitSphere * shakeAmount;
            shakeTimer -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shaking = false;
            shakeTimer = 0f;
            transform.localPosition = preShakePosition;
        }
    }

    public void Shake()
    {
        shaking = true;
        preShakePosition = transform.localPosition;
        shakeTimer = Random.Range(shakeDuration - 0.10f, shakeDuration + 0.10f);
    }

    public void UpdateBoxesHeight(float boxHeight)
    {
        if (boxHeight > highestBoxPosition)
        {
            highestBoxPosition = boxHeight;
        }
    }
        
    private void scrollCamera()
    {
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, 0.15f);
        if (transform.position == initialPosition)
        {
            scrolling = false;
        }
    }

    public void ResetCameraPosition()
    {
        scrolling = true;
    }
 }
