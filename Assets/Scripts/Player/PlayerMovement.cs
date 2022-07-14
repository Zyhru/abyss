using UnityEngine;
using Upgrades;


public class PlayerMovement : MonoBehaviour
{
    // Flip character based on cursor position

    public int playerSpeed;
    public UnityEngine.Camera cam;


    private Rigidbody2D rb;
    private Vector2 moveDir;

    private Animator _animator;
    private bool right;
    private bool moving;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        right = true;
    }


    private void Update()
    {
        ProcessInputs();
        FlipPlayerBasedOnCursorPosition();
    }


    private void FixedUpdate()
    {
        Move();
    }


    private void ProcessInputs()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(x, y).normalized;

        // TODO Play run animation when moving

        moving = rb.velocity.sqrMagnitude > 0;


        _animator.SetBool("Moving", moving);
    }


    private void Move()
    {
        rb.velocity = new Vector2(moveDir.x * playerSpeed, moveDir.y * playerSpeed);
    }

    private void FlipPlayerBasedOnCursorPosition()
    {
        // Cursor position
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldSpace = cam.ScreenToWorldPoint(mousePos);
        mousePos = worldSpace;

        if (right)
        {
            if (mousePos.x < transform.position.x)
            {
                Flip();
            }
        }
        else
        {
            if (mousePos.x > transform.position.x)
            {
                Flip();
            }
        }
    }


    private void Flip()
    {
        right = !right;
        transform.Rotate(0, 180f, 0);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Upgrade"))
        {
            AudioManager.instance.Play("Pickup");
            other.GetComponent<AUpgrade>().Upgrade();
        }
    }
}