using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour {

    public Vector3 jumpup;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;
    void Start()
        {
        rb = GetComponent<Rigidbody>();
        jumpup = new Vector3(0.0f, 2.0f, 0.0f);
        }

    void OnCollisionStay()
        {
        isGrounded = true;
        }

    void Update()
        {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {

            rb.AddForce(jumpup * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            }
        }
    }
