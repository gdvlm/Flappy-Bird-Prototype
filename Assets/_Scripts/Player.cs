using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _isAlive = true;
    
    public bool IsAlive()
    {
        return _isAlive;
    }

    public void SetAlive(bool isAlive)
    {
        _isAlive = isAlive;
    }
}
