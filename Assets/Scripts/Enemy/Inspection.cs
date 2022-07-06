using UnityEngine;

public class Inspection : MonoBehaviour
{
    [SerializeField] [Min(0)] private float time;
    private float nextTime;

    void Start() => nextTime = Time.time + time;

    void Update()
    {
        if (Time.time > nextTime)
        {
            transform.Rotate(Vector2.up, 180.0f);
            nextTime += time;
        }
    }
}
