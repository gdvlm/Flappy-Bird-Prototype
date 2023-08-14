using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform startingPoint;

    [HideInInspector] public bool canMove = true;
    
    private PlayerInput _playerInput;
    private bool _isAlive = true;
    
    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Pipe"))
        {
            DisableMovement();
            canMove = false;
            _isAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            DisableMovement();
            canMove = false;
            _isAlive = false;
        }
    }

    public void ResetCharacter()
    {
        transform.position = startingPoint.position;
        _playerInput.allowMovement = true;
        _playerInput.ResetVelocity();
        _isAlive = true;
    }

    public bool IsAlive()
    {
        return _isAlive;
    }
    
    private void DisableMovement()
    {
        _playerInput.allowMovement = false;
    }

    public void FreezeMovement(bool freeze)
    {
        _playerInput.FreezePlayer(freeze);
    }
}
