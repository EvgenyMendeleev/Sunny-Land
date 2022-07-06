using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class InputMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] [Range(0, 100)] private float _movementSpeed;
    [SerializeField] [Range(0, 5)] private float _jumpForce;

    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround()) Jump(_jumpForce);
    }

    private void Move()
    {
        float playerSpeedX = Input.GetAxis("Horizontal") * _movementSpeed * Time.deltaTime;
        RotateToDirection(playerSpeedX);
        Vector2 playerSpeedVector = new Vector2(playerSpeedX, _rigidbody.velocity.y);
        _animator.SetFloat("speed", playerSpeedVector.magnitude);
        _rigidbody.velocity = playerSpeedVector;
    }

    public void Jump(float jumpForce)
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0.0f);
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void RotateToDirection(float direction)
    {
        if (direction < 0.0f && transform.right.x > 0.0f)
        {
            transform.Rotate(0.0f, 180.0f, 0.0f);
        } 
        else if (direction > 0.0f && transform.right.x < 0.0f)
        {
            transform.Rotate(0.0f, -180.0f, 0.0f);
        }
    }

    private bool isOnGround()
    {
        Vector2 max = _boxCollider.bounds.max;
        Vector2 min = _boxCollider.bounds.min;

        Vector2 corner1 = new Vector2(max.x, min.y - 0.1f);
        Vector2 corner2 = new Vector2(min.x, min.y - 0.2f);

        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        return hit != null ? true : false;
    }
}
