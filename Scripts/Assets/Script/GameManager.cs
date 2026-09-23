using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    [SerializeField] private int coinsCollected = 0;
    [SerializeField] private int currentLevel = 1;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    public void AddCoin(int amount)
    {
        coinsCollected += amount;
        Debug.Log("Coins Collected: " + coinsCollected);

        
    }

    
    public void SetLevel(int levelNumber)
    {
        currentLevel = levelNumber;
        Debug.Log("Current Level: " + currentLevel);
    }

    
    public void ResetGame()
    {
        coinsCollected = 0;
        currentLevel = 1;
    }
}

