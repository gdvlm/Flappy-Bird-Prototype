using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject defeatMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameHud;
    [SerializeField] private Transform pipePairs;
    [SerializeField] private GameObject character;

    private readonly List<PipeMovement> _pipeMovements = new();
    private PlayerMovement _playerMovement;
    private ScoreManager _scoreManager;

    void Awake()
    {
        _playerMovement = character.GetComponent<PlayerMovement>();
        _scoreManager = GetComponent<ScoreManager>();
    }

    void Start()
    {
        _pipeMovements.AddRange(pipePairs.GetComponentsInChildren<PipeMovement>());
    }

    void Update()
    {
        if (_playerMovement.canMove)
        {
            return;
        }
        
        _playerMovement.canMove = true;
        StopGame();
        defeatMenu.SetActive(true);
    }

    public void StartGame()
    {
        defeatMenu.SetActive(false);
        startMenu.SetActive(false);
        gameHud.SetActive(true);
        character.SetActive(true);
        _playerMovement.ResetCharacter();
        _scoreManager.ResetScore();

        foreach (PipeMovement pipeMovement in _pipeMovements)
        {
            pipeMovement.SetToInitialPosition();
            pipeMovement.EnableMovement(true);
        }
    }

    public void StopGame()
    {
        gameHud.SetActive(false);
        
        foreach (PipeMovement pipeMovement in _pipeMovements)
        {
            pipeMovement.EnableMovement(false);
        }
    }

    public void PauseGame()
    {
        StopGame();
        pauseMenu.SetActive(true);
        _playerMovement.FreezeMovement(true);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        gameHud.SetActive(true);
        _playerMovement.FreezeMovement(false);
        
        foreach (PipeMovement pipeMovement in _pipeMovements)
        {
            pipeMovement.EnableMovement(true);
        }        
    }
}
