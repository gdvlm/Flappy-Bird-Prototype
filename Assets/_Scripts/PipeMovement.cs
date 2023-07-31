using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        float distance = movementSpeed * Time.fixedDeltaTime;
        // transform.position += new Vector3(-distance, 0, 0);
        transform.position += Vector3.left * distance;
    }
}
