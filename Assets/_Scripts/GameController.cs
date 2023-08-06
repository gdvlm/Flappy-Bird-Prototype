using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject defeatMenu;
    [SerializeField] private GameObject gameHud;
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
        defeatMenu.SetActive(true);
    }

    public void StartGame()
    {
        defeatMenu.SetActive(false);
        startMenu.SetActive(false);
        gameHud.SetActive(true);
        character.SetActive(true);
        _character.ResetCharacter();

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
}
