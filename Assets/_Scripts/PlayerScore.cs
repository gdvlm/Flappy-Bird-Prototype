using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerScore : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    private Player _player;
    
    void Awake()
    {
        _player = GetComponent<Player>();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("ScoreBox") && _player.IsAlive())
        {
            scoreManager.IncrementScore();
        }
    }        
}
