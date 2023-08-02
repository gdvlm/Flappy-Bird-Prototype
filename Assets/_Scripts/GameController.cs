using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Transform pipePairs;
    [SerializeField] private GameObject character;

    private readonly List<PipeMovement> _pipeMovements = new();
    private Character _character;

    void Awake()
    {
        _character = character.GetComponent<Character>();
    }

    void Start()
    {
        _pipeMovements.AddRange(pipePairs.GetComponentsInChildren<PipeMovement>());
    }

    void Update()
    {
        if (!_character.characterLost)
        {
            return;
        }
        
        _character.characterLost = false;
        StopGame();
        // Show defeat UI
    }

    public void StartGame()
    {
        menuPanel.SetActive(false);
        character.SetActive(true);
        _character.MoveToStartingPosition();
        _character.AllowMovement();

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
