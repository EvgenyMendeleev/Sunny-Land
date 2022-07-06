using UnityEngine;

public class LinearMovement : MovementSettings
{
    [SerializeField] private bool isRotateInTheEndPoint;

    void FixedUpdate() => Move();

    protected override void Move()
    {
        if(isEndPoint())
        {
            movementDirection *= -1;
            if(isRotateInTheEndPoint) transform.Rotate(Vector2.up, 180.0f);
        }
        transform.Translate(movementDirection * speed, Space.World);
    }
}
