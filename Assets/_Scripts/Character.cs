using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Transform startingPoint;
    [SerializeField] private ScoreKeeper scoreKeeper;

    [HideInInspector] public bool canMove = true;
    
    private PlayerAction _playerAction;
    private bool _isAlive = true;
    
    void Awake()
    {
        _playerAction = GetComponent<PlayerAction>();
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
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("ScoreBox") && _isAlive)
        {
            scoreKeeper.IncrementScore();
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
        _playerAction.allowMovement = true;
        _playerAction.ResetVelocity();
        _isAlive = true;
    }
    
    private void DisableMovement()
    {
        _playerAction.allowMovement = false;
    }

    public void FreezeMovement(bool freeze)
    {
        _playerAction.FreezePlayer(freeze);
    }
}
