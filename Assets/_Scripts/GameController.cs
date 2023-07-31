using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Transform pipePairs;
    [SerializeField] private GameObject character;

    private bool _isPlaying;
    private PlayerAction _playerAction;
    public List<PipeMovement> _pipeMovements = new();

    void Awake()
    {
        _playerAction = character.GetComponent<PlayerAction>();
    }

    void Start()
    {
        _isPlaying = false;
        _pipeMovements.AddRange(pipePairs.GetComponentsInChildren<PipeMovement>());
    }

    public void StartGame()
    {
        menuPanel.SetActive(false);
        _playerAction.MoveToStartingPosition();
        character.SetActive(true);
        
        foreach (PipeMovement pipeMovement in _pipeMovements)
        {
            pipeMovement.EnableMovement(true);
        }
    }

    public void StopGame()
    {
        foreach (PipeMovement pipeMovement in _pipeMovements)
        {
            pipeMovement.EnableMovement(false);
        }
    }
}
