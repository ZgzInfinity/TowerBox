
using UnityEngine;

public class Box : MonoBehaviour
{

    private Rigidbody2D boxRigidBody2D;

    private bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        boxRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            boxRigidBody2D.gravityScale = 1f;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((!hasCollided && collision.collider.CompareTag(GameTags.Box) || collision.collider.CompareTag(GameTags.Ground)))
        {
            hasCollided = true;
            GameManager.Instance.setScore();
            checkShake();
        }
        CameraManager.Instance.UpdateBoxesHeight(transform.position.y);
    }

    private void checkShake()
    {
        int shakeRandom = Random.Range(0, 10);
        if (shakeRandom > 7)
        {
            CameraManager.Instance.Shake();
        }
    }
}
