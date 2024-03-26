using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private float _normalAcceleration = 100f;
    [SerializeField]
    private float _boostAcceleration = 150f;
    private float _acceleration;


    [SerializeField]
    private float _boostSpeed = 20f;
    [SerializeField]
    private float _normalSpeed = 10f;
    private float _maxSpeed;

    private Vector2 _moveInput;

    private void Start()
    {
        _maxSpeed = _normalSpeed;
        _acceleration = _normalAcceleration;

        _rigidBody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        AddMovementForce();
    }

    private void AddMovementForce()
    {
        if (_moveInput.x == 0 && _moveInput.y == 0)
            return;

        if (_rigidBody2D.velocity.magnitude < _maxSpeed)
        {
            var force = _acceleration * new Vector2(_moveInput.x, _moveInput.y);
            _rigidBody2D.AddForce(force);
        }
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    private void OnFire()
    {
        Debug.Log("FIRE");
    }

    private void OnBoost(InputValue value)
    {
        if (value.isPressed)
        {
            _spriteRenderer.color = Color.red;
            _acceleration = _boostAcceleration;
            _maxSpeed = _boostSpeed;
        }
        else
        {
            _spriteRenderer.color = Color.white;
            _acceleration = _normalAcceleration;
            _maxSpeed = _normalSpeed;
        }
    }
}
