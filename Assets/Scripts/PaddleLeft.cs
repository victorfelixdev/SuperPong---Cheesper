using UnityEngine;

public class PaddleLeft : MonoBehaviour
{

    private PlayControls controls;

    [SerializeField] private Vector2 _moveInput;

    private Vector2 _movementDirection;
    private CharacterController _paddleController;

    public float _paddleSpeed = 10f;

    private void Awake()
    {
        controls = new PlayControls();

        controls.Left.Move.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
        controls.Left.Move.canceled += ctx => _moveInput = Vector2.zero;
    }

    void Update()
    {
        MovePlayer();
    }

    private void Start()
    {
        _paddleController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void MovePlayer()
    {
        _movementDirection = new Vector2(0f, _moveInput.y).normalized;
        _paddleController.Move(_movementDirection * _paddleSpeed * Time.deltaTime);
    }
}
