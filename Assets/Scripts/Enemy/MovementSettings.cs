using UnityEngine;
using UnityEngine.UI;

public abstract class MovementSettings : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 1.0f)] private float distance;
    [SerializeField] [Range(0.0f, 360.0f)] private float rotationAngle;
    [SerializeField] [Range(0.0f, 0.1f)] protected float speed;
    protected Vector3 movementDirection;
    private Vector3 startPosition;

    private void Awake() => startPosition = transform.position;

    /*
     * ƒублирование в Start и OnValidate св€зано с тем, что OnValidate вызываетс€, когда в инспекторе мен€ютс€ значени€.
     * ¬ случае с release - версией OnValidate не вызываетс€, следовательно не инициализируетс€ вектор направлени€ движени€.
     * ѕоэтому в release - версии враг просто стоит, име€ координаты вектора движени€ (0, 0, 0).
     */
    private void Start() => movementDirection = (CalculateEndPoint(transform.position, rotationAngle) - transform.position).normalized;
    private void OnValidate() => movementDirection = (CalculateEndPoint(transform.position, rotationAngle) - transform.position).normalized;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, CalculateEndPoint(Vector3.zero, rotationAngle));
        Gizmos.DrawRay(transform.position, CalculateEndPoint(Vector3.zero, rotationAngle + 180.0f));
        Gizmos.DrawSphere(CalculateEndPoint(transform.position, rotationAngle), 0.05f);
    }

    private Vector3 CalculateEndPoint(Vector3 startPoint, float angle)
    {
        float new_x = startPoint.x + distance * Mathf.Cos(angle * Mathf.PI / 180.0f);
        float new_y = startPoint.y + distance * Mathf.Sin(angle * Mathf.PI / 180.0f);
        return new Vector3(new_x, new_y, 0.0f);
    }

    protected bool isEndPoint()
    {
        return Mathf.Pow(transform.position.x - startPosition.x, 2.0f) + Mathf.Pow(transform.position.y - startPosition.y, 2.0f) > Mathf.Pow(distance, 2.0f);
    }

    protected abstract void Move();
}
