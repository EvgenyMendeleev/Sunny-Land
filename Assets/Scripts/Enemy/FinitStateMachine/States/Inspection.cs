using UnityEngine;
using StateMachine;

public class Inspection : IEnemyState
{
    private readonly float _time;
    private float _nextTime;

    private readonly Transform _gameObjectTransform;

    public Inspection(Transform transform, float time)
    {
        _nextTime = Time.time + time;
        _time = time;
        _gameObjectTransform = transform;
    }

    public bool UpdateState()
    {
        if (Time.time > _nextTime)
        {
            _gameObjectTransform.Rotate(Vector2.up, 180.0f);
            _nextTime += _time;
        }

        return false;
    }
}
