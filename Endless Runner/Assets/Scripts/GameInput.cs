using UnityEngine;
using UnityEngine.Events;

public class GameInput : MonoBehaviour
{
    // [SerializeField] GameObject _player;

    // private PlayerInputActions _playerInputActions;

    public static GameInput Instance { get; private set; }

    public UnityEvent OnSideMoveEvent;

    private void Awake()
    {
        Instance = this;

        // _playerInputActions = new PlayerInputActions();
        // _playerInputActions.Enable();
    }

    public void MoveForward()
    {
        // Add start condition

        PlayerMovement.Instance.transform.Translate(Vector3.forward * Time.fixedDeltaTime * PlayerMovement.Instance.ForwardSpeed, Space.World);  
    }

    public void MoveSides()
    {
        // Add start condition

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            OnSideMoveEvent.Invoke();
            PlayerMovement.Instance.transform.Translate(Vector3.left * Time.fixedDeltaTime * PlayerMovement.Instance.SidesSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            OnSideMoveEvent.Invoke();
            PlayerMovement.Instance.transform.Translate(Vector3.right * Time.fixedDeltaTime * PlayerMovement.Instance.SidesSpeed, Space.World);
        }
    }

    //public Vector3 GetMovementVector()
    //{
    //    Vector3 inputVector = _playerInputActions.Player.Move.ReadValue<Vector3>();

    //    return inputVector;
    // }
}
