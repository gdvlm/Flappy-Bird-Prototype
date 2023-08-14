using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform startingPoint;

    [HideInInspector] public bool canMove = true;

    private Player _player;
    private PlayerInput _playerInput;
    
    void Awake()
    {
        _player = GetComponent<Player>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Pipe"))
        {
            DisableMovement();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            DisableMovement();
        }
    }

    public void ResetCharacter()
    {
        transform.position = startingPoint.position;
        _playerInput.allowMovement = true;
        _playerInput.ResetVelocity();
        _player.SetAlive(true);
    }
    
    private void DisableMovement()
    {
        _playerInput.allowMovement = false;
        canMove = false;
        _player.SetAlive(false);
    }
}
