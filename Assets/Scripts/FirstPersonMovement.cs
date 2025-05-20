using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float _speed = 5f;
    public float _jumpForce = 8f;
    private Rigidbody rb;
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * HorizontalInput + transform.forward * VerticalInput;
        Vector3 velocity = moveDirection * _speed;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);




    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
}
