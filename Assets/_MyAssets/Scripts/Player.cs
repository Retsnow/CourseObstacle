using UnityEngine;

public class Player : MonoBehaviour
{
    private const string IS_WALKING = "isWalking";

    [SerializeField] private float _playerSpeed = 10f;
    [SerializeField] private float _rotationSpeed = 1000f;

    private Animator _animator;
    private PlayerInputActions _playerInputActions;
    private Rigidbody _rb;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
    }

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb= GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerMovements();

    }

    private void PlayerMovements()
    {
        /*Ancien Input Manager
        float dirX = Input.GetAxis("Horizontal");
        float dirZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(dirX, 0f, dirZ);
        */

        Vector2 direction2D = _playerInputActions.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(direction2D.x, 0f, direction2D.y);

        // Mormalise mon Vecteur avec une valeur maximale de 1
        direction.Normalize();

        _rb.linearVelocity = direction * Time.fixedDeltaTime * _playerSpeed;

        //transform.Translate(direction * Time.deltaTime * _playerSpeed, Space.World);



        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.fixedDeltaTime);
            _animator.SetBool(IS_WALKING, true);
        }
        else
        {
            _animator.SetBool(IS_WALKING, false);
        }
    }
}
