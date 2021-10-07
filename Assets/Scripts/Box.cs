
using UnityEngine;

public class Box : MonoBehaviour
{
    public float horizontalSpeed = 3f;

    private Rigidbody2D boxRigidBody2D;

    private bool hasCollided = false;

    private Vector2 pointA;
    private Vector2 pointB;

    private Transform boxSpawner;
    private bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        boxRigidBody2D = GetComponent<Rigidbody2D>();
        boxSpawner = CameraManager.Instance.boxSpawner;

        pointA = new Vector2(-2, boxSpawner.position.y);
        pointB = new Vector2(2, boxSpawner.position.y);
    }

    private void Update()
    {
        if (GameManager.Instance.isGameActive)
        {
            if (boxRigidBody2D.gravityScale == 0f)
            {
                Move();
            }

            if (Input.GetMouseButtonDown(0))
            {
                boxRigidBody2D.gravityScale = 1f;
            }
        }
        else
        {
            if (!hasCollided)
            {
                this.boxRigidBody2D.gravityScale = 1f;
            }
        }
    }

    private void Move()
    {
        if (movingRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB, horizontalSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA, horizontalSpeed * Time.deltaTime);
        }

        if (transform.position.x >= pointB.x)
        {
            movingRight = false;
        }
        else if (transform.position.x <= pointA.x)
        {
            movingRight = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((!hasCollided && collision.collider.CompareTag(GameTags.Box) || collision.collider.CompareTag(GameTags.Ground)))
        {
            hasCollided = true;
            checkShake();
            GameManager.Instance.setScore();
            CameraManager.Instance.UpdateBoxesHeight(transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTags.GameOverZone))
        {
            GameManager.Instance.GameOver();
        }
    }

    private void checkShake()
    {
        if (GameManager.Instance.Score == 0)
        {
            CameraManager.Instance.Shake();
        }
        else
        {
            int shakeRandom = Random.Range(0, 10);

            if (shakeRandom > 7)
            {
                CameraManager.Instance.Shake();
            }
        }
    }
}
