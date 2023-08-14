using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    
    private PlayerMovement _playerMovement;
    
    void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("ScoreBox") && _playerMovement.IsAlive())
        {
            scoreManager.IncrementScore();
        }
    }        
}
