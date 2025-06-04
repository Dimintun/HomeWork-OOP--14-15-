using UnityEngine;

public class Movement : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;

    private float _deadZone = 0.2f;

    private float _xInput;
    private float _yInput;

    private Vector3 _direction;
    private Quaternion _lookRotation;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if (_characterController == null)
            Debug.Log("Отсутствует компонент");
    }

    void Update()
    {
        Move();

        RotateToDirection(_direction);
    }
    private void Move()
    {
        _xInput = Input.GetAxis(HorizontalAxisName);
        _yInput = Input.GetAxis(VerticalAxisName);

        _direction = new Vector3(_xInput, 0, _yInput);

        if (_direction.magnitude < _deadZone)
            return;

        _direction = _direction.normalized;
        _characterController.Move(_direction * _speed * Time.deltaTime);
    }

    private void RotateToDirection(Vector3 direction)
    {
        if (direction.magnitude < _deadZone)
            return;

        _lookRotation = Quaternion.LookRotation(direction);
        float step = _speedRotation * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookRotation, step);
    }
}

