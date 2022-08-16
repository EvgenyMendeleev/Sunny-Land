using UnityEngine;
using StateMachine;

public class JumpingAttack : IEnemyState
{
    private Transform _playerTransform;
    private GameObject _gameObject;
    private float _lookDistance;

    public JumpingAttack(GameObject gameObject, Transform targetTransform, float lookDistance)
    {
        _playerTransform = targetTransform;
        _gameObject = gameObject;
        _lookDistance = lookDistance;
    }

    public bool UpdateState()
    {
        Vector2 distanceFromPlayer = _playerTransform.position - _gameObject.transform.position;
        if (distanceFromPlayer.magnitude > _lookDistance) return true;
        
        distanceFromPlayer.y = 0.0f;
        distanceFromPlayer.Normalize();

        GroundChecker groundChecker = _gameObject.transform.Find("GroundChecker").GetComponent<GroundChecker>();
        if (groundChecker.IsGround)
        {
            Rigidbody2D rigidbody = _gameObject.GetComponent<Rigidbody2D>();
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(Vector2.up * 3.5f, ForceMode2D.Impulse);
        }

        return false;
    }
}
