using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 12f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        float move = 0f;
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) move = -1f;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) move = 1f;

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (kb.spaceKey.wasPressedThisFrame || kb.upArrowKey.wasPressedThisFrame || kb.wKey.wasPressedThisFrame)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}