using UnityEngine;

public class Movement : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    private float _deadZone = 0.1f;

    private float _xInput;
    private float _yInput;
    
    private Vector3 _direction;
    private Quaternion _rotation;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if (_characterController == null)
            Debug.Log("Отсутствует компонент");

    }

    void Update()
    {
        _xInput = Input.GetAxis(HorizontalAxisName);
        _yInput = Input.GetAxis(VerticalAxisName);

        if (Mathf.Abs(_xInput) < _deadZone || Mathf.Abs(_yInput) < _deadZone)
            return;

            _direction = GetNormalizeDirection(_xInput, _yInput);

        _characterController.Move(_direction * _speed *  Time.deltaTime);
    }

    private Vector3 GetNormalizeDirection(float xInput, float yInput)
    {
        Vector3 direction = new Vector3(xInput, 0, yInput);

        direction.Normalize();
        return direction;
    }
}

