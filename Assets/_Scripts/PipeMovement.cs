using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform startPosition;

    private bool _allowMovement = false;
    private Vector3 _resetPosition;

    void Start()
    {
        _resetPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (!_allowMovement)
        {
            return;
        }
        
        float distance = movementSpeed * Time.fixedDeltaTime;
        transform.position += Vector3.left * distance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("PipeReset"))
        {
            transform.position = startPosition.position;
        }
    }

    public void SetToInitialPosition()
    {
        transform.position = _resetPosition;
    }

    public void EnableMovement(bool allowMovement)
    {
        _allowMovement = allowMovement;
    }
}
