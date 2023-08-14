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
    private PlayerMovement playerMovement;
    private ScoreManager scoreManager;

    void Awake()
    {
        playerMovement = character.GetComponent<PlayerMovement>();
        scoreManager = GetComponent<ScoreManager>();
    }

    void Start()
    {
        _pipeMovements.AddRange(pipePairs.GetComponentsInChildren<PipeMovement>());
    }

    void Update()
    {
        if (playerMovement.canMove)
        {
            return;
        }
        
        playerMovement.canMove = true;
        StopGame();
        defeatMenu.SetActive(true);
    }

    public void StartGame()
    {
        defeatMenu.SetActive(false);
        startMenu.SetActive(false);
        gameHud.SetActive(true);
        character.SetActive(true);
        playerMovement.ResetCharacter();
        scoreManager.ResetScore();

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
        playerMovement.FreezeMovement(true);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        gameHud.SetActive(true);
        playerMovement.FreezeMovement(false);
        
        foreach (PipeMovement pipeMovement in _pipeMovements)
        {
            pipeMovement.EnableMovement(true);
        }        
    }
}
