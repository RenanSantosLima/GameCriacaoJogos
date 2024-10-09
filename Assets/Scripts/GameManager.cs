using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputManager inputManager {get; private set;}

    private void Awake()
    {
        if (Instance != null) Destroy(this.gameObject);
        Instance = this;
        
        inputManager = new InputManager();
    }
}
