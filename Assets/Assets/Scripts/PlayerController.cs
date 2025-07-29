using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSPeed = 1.5f;
    [SerializeField] GameObject restartButton;
    float moveInput;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }


    void Update()
    {
        moveInput = new Vector3(0f, 0f, 0f).z;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {

        transform.Translate(rb.linearVelocity.x, rb.linearVelocity.y, moveInput * moveSPeed * Time.fixedDeltaTime);
        Mathf.Clamp(transform.position.z, -0.8f, 0.8f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            restartButton.SetActive(true);
            GameManager.Instance.GameOver();
        ObstacleSpawner.Instance.enabled = false; 
        }
        
    }
}
