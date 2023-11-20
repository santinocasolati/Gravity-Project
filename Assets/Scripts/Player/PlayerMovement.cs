using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public float groundCheckDistance = 0.1f;

    private Rigidbody2D rb;
    private bool isRunning = false;
    private Vector2 moveTowards;
    private Vector2 jumpTowards;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveTowards = transform.right;
        jumpTowards = transform.up;
    }

    void FixedUpdate()
    {
        CheckInput();
    }

    void CheckInput()
    {
        isRunning = Input.GetAxisRaw("Run") > 0;

        CheckMovement();
        CheckJump();
    }

    void CheckMovement()
    {
        float mov = Input.GetAxisRaw("Horizontal");
        Vector2 moveDirection = moveTowards * mov;

        float ms = moveSpeed;
        if (isRunning)
        {
            ms *= 1.5f;
        }

        rb.position += ms * Time.fixedDeltaTime * moveDirection;
    }

    void CheckJump()
    {
        float jump = Input.GetAxisRaw("Jump");
        bool grounded = IsGrounded();

        if (jump == 1 && grounded)
        {
            rb.AddForce(jumpTowards * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -jumpTowards, groundCheckDistance, LayerMask.GetMask("Bounds"));
        return hit.collider != null;
    }

    public void SetDirections(Vector2 move, Vector2 jump)
    {
        moveTowards = move;
        jumpTowards = jump;
    }
}
