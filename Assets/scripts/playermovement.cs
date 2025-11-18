using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    [SerializeField] private float wallJumpCooldown;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // float horizontalInput = Input.GetAxis("Horizontal");
        // body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // if (Input.GetKey(KeyCode.Space) && isGrounded())
        // {
        //     Jump();
        // }

        // if (Input.GetKey(KeyCode.Space) && onWall())
        // {
        //     Jump();
        // }

    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHitX = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHitX.collider != null;
    }
}

