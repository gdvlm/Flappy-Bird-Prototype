using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float jumpAmount;
    [SerializeField] private UICanvasHitDetector uiCanvasHitDetector;
    
    [HideInInspector] public bool allowMovement = false;
    
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
        if (uiCanvasHitDetector.IsPointerOverUI() || !allowMovement)
        {
            return;
        }
        
        // Setting the velocity directly allows us to ignore the current downward force
        _rigidbody2D.velocity = new Vector2(0, jumpAmount);
    }

    public void ResetVelocity()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }

    public void FreezePlayer(bool freeze)
    {
        if (freeze)
        {
            _inputActionsWrapper.Gameplay.Disable();
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
            return;
        }

        _inputActionsWrapper.Gameplay.Enable();
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        _rigidbody2D.WakeUp(); // Important to wake up the Rigidbody!
    }
}
