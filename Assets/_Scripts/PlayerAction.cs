using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private float jumpAmount;
    [SerializeField] private Transform startingPoint;
    
    private Rigidbody2D _rigidbody2D;
    private InputActionsWrapper _inputActionsWrapper;
    
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputActionsWrapper = new InputActionsWrapper();
        _inputActionsWrapper.Gameplay.Jump.performed += OnJump;
    }

    void OnEnable()
    {
        _inputActionsWrapper.Gameplay.Enable();
    }

    void OnDisable()
    {
        _inputActionsWrapper.Gameplay.Disable();
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        // Setting the velocity directly allows us to ignore the current downward force
        _rigidbody2D.velocity = new Vector2(0, jumpAmount);
    }

    public void MoveToStartingPosition()
    {
        transform.position = startingPoint.position;
    }
}
