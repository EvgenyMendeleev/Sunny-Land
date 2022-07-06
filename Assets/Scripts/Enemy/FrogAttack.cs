using UnityEngine;

public class FrogAttack : MonoBehaviour
{
    //TODO: Подумать как правильно реализовать прыжок в сторону игрока. КЛАСС НЕ РАБОЧИЙ НА ДАННЫЙ МОМЕНТ.
    public Transform PlayerTransform { get; set; }
    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidbody;

    void Start()
    {
    }

    void FixedUpdate()
    {
        if (isOnGround())
        {
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
