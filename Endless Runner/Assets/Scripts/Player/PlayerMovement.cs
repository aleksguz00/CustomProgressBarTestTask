using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed = 10f;
    [SerializeField] private float _sidesSpeed = 10f;

    // private Rigidbody _rb;

    public static PlayerMovement Instance { get; private set; }
    public float ForwardSpeed { get; set; }
    public float SidesSpeed { get; set; }

    private void Awake()
    {
        Instance = this;
        ForwardSpeed = _forwardSpeed;
        SidesSpeed = _sidesSpeed;

        // _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveForward();
        SidesMovement();
    }

    private void MoveForward()
    {
        GameInput.Instance.MoveForward();

        // _rb.MovePosition(Vector3.forward * Time.fixedDeltaTime * _forwardSpeed);
    }

    private void SidesMovement()
    {
        GameInput.Instance.MoveSides();

        // Vector3 inputVector = GameInput.Instance.GetMovementVector();
        // _rb.MovePosition(_rb.position + inputVector * (_sidesSpeed * Time.fixedDeltaTime));
    }
}
