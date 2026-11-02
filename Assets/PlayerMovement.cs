using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    Animator anim;
    Vector2 move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        move = Vector2.zero;
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) move.x = -1;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) move.x = 1;
        if (kb.sKey.isPressed || kb.downArrowKey.isPressed) move.y = -1;
        if (kb.wKey.isPressed || kb.upArrowKey.isPressed) move.y = 1;
        move = move.normalized;

        bool moving = move != Vector2.zero;
        anim.SetBool("IsMoving", moving);

        if (moving)
        {
            anim.SetFloat("MoveX", move.x);
            anim.SetFloat("MoveY", move.y);
            anim.SetFloat("LastX", move.x);
            anim.SetFloat("LastY", move.y);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = move * speed;
    }
}