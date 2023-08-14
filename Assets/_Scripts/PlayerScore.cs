using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    
    private PlayerMovement playerMovement;
    
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("ScoreBox") && playerMovement.IsAlive())
        {
            scoreManager.IncrementScore();
        }
    }        
}
