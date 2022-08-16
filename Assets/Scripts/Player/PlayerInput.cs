using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameObserver;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerInput : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] [Range(0, 2)] private float _movementSpeed;
    [SerializeField] [Range(0, 5)] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private GroundChecker _groundChecker;

    public static NotifyHandler menuObserver;

    #region Unity's functions
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _groundChecker = transform.Find("GroundChecker").GetComponent<GroundChecker>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) menuObserver?.Invoke(GameEvents.STOP_GAME);
        else if (Input.GetKeyDown(KeyCode.R)) menuObserver?.Invoke(GameEvents.RESTART_LEVEL);
    }

    private void FixedUpdate()
    {
        float directionX = Input.GetAxis("Horizontal");
        _rigidbody.bodyType = directionX == 0 && _groundChecker.IsGround ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) Move(directionX);
        if (Input.GetKey(KeyCode.Space) && _groundChecker.IsGround)
        {
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            Jump(_jumpForce);
        }
    }

    private void LateUpdate()
    {
        _animator.SetFloat("speed", _rigidbody.velocity.magnitude);
        _animator.SetBool("isGround", _groundChecker.IsGround);
        _animator.SetFloat("fallingVector", _rigidbody.velocity.y);
    }
    #endregion

    #region Player's abilities
    public void Jump(float jumpForce)
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0.0f);
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    private void Move(float directionX)
    {
        if (directionX < 0.0f && transform.right.x > 0.0f) transform.Rotate(0.0f, 180.0f, 0.0f);
        else if (directionX > 0.0f && transform.right.x < 0.0f) transform.Rotate(0.0f, -180.0f, 0.0f);

        Vector2 playerDirection = new Vector2(directionX * _movementSpeed, _rigidbody.velocity.y);
        _rigidbody.velocity = playerDirection;
    }
    #endregion
}
