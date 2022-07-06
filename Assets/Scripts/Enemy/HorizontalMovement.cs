using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 1.0f)] private float distance;
    [SerializeField] [Range(0.0f, 0.1f)] private float speed;

    private float startX;
    public float MoveDirection { private get; set; }

    void Start()
    {
        MoveDirection = transform.right.x;
        startX = transform.position.x;
    }

    void FixedUpdate()
    {
        if (transform.position.x > (startX + distance) || transform.position.x < (startX - distance))
        {
            MoveDirection *= -1;
            transform.Rotate(Vector2.up, MoveDirection * 180.0f);
        }
    }
}
