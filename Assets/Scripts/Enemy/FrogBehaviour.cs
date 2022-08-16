using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class FrogBehaviour : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 10.0f)] private float _inspectionDistance;
    [SerializeField] [Range(0.0f, 7.0f)] private float _inspectionTime;

    private IEnemyState state;
    private Transform _playerTransform;
    private Animator _animator;
    private GroundChecker _groundChecker;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        state = new Inspection(transform, _inspectionTime);
        _playerTransform = FindObjectOfType<Player>().transform;
        _animator = GetComponent<Animator>();
        _groundChecker = transform.Find("GroundChecker").GetComponent<GroundChecker>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_playerTransform == null) return;
        Vector2 distanceFromPlayer = transform.position - _playerTransform.position;
        if (distanceFromPlayer.magnitude < _inspectionDistance && state is not JumpingAttack) state = new JumpingAttack(gameObject, _playerTransform, _inspectionDistance);
        else if (_groundChecker.IsGround && state is not Inspection) state = new Inspection(transform, _inspectionTime);

        _animator.SetBool("isGround", _groundChecker.IsGround);
        _animator.SetFloat("fallingVector", _rigidbody.velocity.y);
    }
    void FixedUpdate()
    {
        state.UpdateState();
    }
}
