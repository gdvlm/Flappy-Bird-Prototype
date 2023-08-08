using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Transform startingPoint;
    [SerializeField] private ScoreKeeper scoreKeeper;

    [HideInInspector] public bool characterLost = false;
    private PlayerAction _playerAction;

    void Awake()
    {
        _playerAction = GetComponent<PlayerAction>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Pipe"))
        {
            DisableMovement();
            characterLost = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("ScoreBox") && !characterLost)
        {
            scoreKeeper.IncrementScore();
        }
    }    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            DisableMovement();
            characterLost = true;
        }
    }

    public void ResetCharacter()
    {
        transform.position = startingPoint.position;
        _playerAction.allowMovement = true;
        _playerAction.ResetVelocity();
    }
    
    private void DisableMovement()
    {
        _playerAction.allowMovement = false;
    }
}
