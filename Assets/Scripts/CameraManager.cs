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

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (shaking)
        {
            CheckShakeEffect();
        }
        CheckCameraPosition();
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
            shaking = true;
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
        
 }
