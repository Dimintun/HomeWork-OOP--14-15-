using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private  float _speed;
    [SerializeField] private float _speedRotation;
    public float Speed
    {
        
        get => _speed;
        set
        {
            if (value >= 0)
                _speed = value;
            else
                Debug.Log("Отрицательная скорость");
        }
    }


    private float _deadZone = 0.2f;

    private CharacterController _characterController;

    private float _xInput;
    private float _yInput;

    private Vector3 _direction;
    private Quaternion _lookRotation;

    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        Move();

        RotateToDirection(_direction);
    }

    private void RotateToDirection(Vector3 direction)
    {
        if (direction.magnitude < _deadZone)
            return;

        _lookRotation = Quaternion.LookRotation(direction);
        float step = _speedRotation * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookRotation, step);
    }    
    private void Move()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        _yInput = Input.GetAxisRaw("Vertical");

        _direction = new Vector3(_xInput, 0, _yInput);

        if (_direction.magnitude < _deadZone)
        return;

            _direction = _direction.normalized;
            _characterController.Move(_direction * _speed * Time.deltaTime);
        
            
    }
}
