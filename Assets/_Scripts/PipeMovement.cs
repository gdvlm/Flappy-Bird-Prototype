using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform startPosition;

    private bool _allowMovement = false;

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

    public void EnableMovement(bool allowMovement)
    {
        _allowMovement = allowMovement;
    }
}
