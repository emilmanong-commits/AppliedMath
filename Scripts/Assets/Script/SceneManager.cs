using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get; private set; }

    void Awake()
    {
        // Check if an instance already exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set the instance to this object and protect it from deletion
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
