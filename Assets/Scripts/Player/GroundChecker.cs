using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private BoxCollider2D _boxCollider;

    private Vector2 corner1;
    private Vector2 corner2;

    public bool IsGround 
    {
        get;
        private set;
    }

    private void Start()
    {
        _boxCollider = GetComponentInParent<BoxCollider2D>();
    }

    private void Update()
    {
        Vector2 max = _boxCollider.bounds.max;
        Vector2 min = _boxCollider.bounds.min;

        corner1 = new Vector2(max.x - 0.02f, min.y);
        corner2 = new Vector2(min.x + 0.02f, min.y - 0.02f);

        Collider2D hit = Physics2D.OverlapArea(corner1, corner2, 1 << 6);  //Маска 6: Ground
        IsGround = hit != null? true : false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(corner1, new Vector2(corner1.x, corner2.y));
        Gizmos.DrawLine(corner1, new Vector2(corner2.x, corner1.y));
        Gizmos.DrawLine(corner2, new Vector2(corner2.x, corner1.y));
        Gizmos.DrawLine(corner2, new Vector2(corner1.x, corner2.y));
    }
}
