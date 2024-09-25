using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Ground Check")]
    [SerializeField] private int m_playerHeight;
    [SerializeField] private LayerMask m_floorLayer, m_cubeLayer;
    [SerializeField] private bool m_grounded;

    [Header("Movement")]
    [SerializeField] private InputActionReference m_movementDirection;
    [SerializeField] private float m_jumpForce, m_movementSpeed, m_groundDrag, m_startSpeed, m_halfedSpeed;

    [Header("Box shit")]
    [SerializeField] private Transform m_boxHolder;
    [SerializeField] private Transform m_box;
    private bool m_holding;

    private Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_halfedSpeed = m_movementSpeed / 1.3f;
        m_startSpeed = m_movementSpeed;
    }

    //private void OnPause()
    //{
    //    PlayerInfo.Instance.isPaused = !PlayerInfo.Instance.isPaused;
    //}

    private void OnGrab()
    {
        Debug.Log("Attempting to grab !");
        if (m_box.position.x < m_boxHolder.position.x + 1 && m_box.position.x > m_boxHolder.position.x - 1 && m_box.position.y < m_boxHolder.position.y + 1 && m_box.position.y > m_boxHolder.position.y - 1 && !m_holding)
        {
            m_holding = true;
            m_box.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (m_holding)
        {
            m_holding = false;
            m_box.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnJump()
    {
        // Jumping when you press the jump button
        if (m_grounded)
        {
            m_rb.AddForce(Vector2.up * m_jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Moving()
    {
        // Movement logic
        Vector2 moveInput = m_movementDirection.action.ReadValue<Vector2>();
        Vector2 moveDirection = transform.up * moveInput.y + transform.right * moveInput.x;

        m_rb.AddForce(moveDirection.normalized * m_movementSpeed * 10f, ForceMode2D.Force);
    }

    private void SpeedControl()
    {
        // Limit Velocity when needed
        Vector2 flatVel = new Vector2(m_rb.velocity.x, 0);

        if (!m_grounded)
        {
            m_movementSpeed = m_halfedSpeed;
        }
        else
        {
            m_movementSpeed = m_startSpeed;
        }
        if (flatVel.magnitude > m_movementSpeed)
        {
            Vector2 limitedVel = flatVel.normalized * m_movementSpeed;
            m_rb.velocity = new Vector2(limitedVel.x, m_rb.velocity.y);
        }
    }

    void Update()
    {
        // Checking if touching the ground
        if (Physics2D.Raycast(transform.position, Vector2.down, m_playerHeight * 0.5f + 0.2f, m_floorLayer) || Physics2D.Raycast(transform.position, Vector2.down, m_playerHeight * 0.5f + 0.2f, m_cubeLayer))
        {
            m_grounded = true;
        }
        else
        {
            m_grounded = false;
        }

        if (m_grounded)
        {
            m_rb.drag = m_groundDrag;
        }
        else
        {
            m_rb.drag = 0;
        }

        if (m_holding)
        {
            m_box.position = m_boxHolder.position;
        }

        SpeedControl();
    }

    private void FixedUpdate()
    {
        Moving();
    }
}
