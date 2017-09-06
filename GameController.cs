using UnityEngine;

/// <summary>
/// Class which persists for the lifetime of the application
/// </summary>
public class GameController : MonoBehaviour
{
    /// <summary>
    /// GameController singleton
    /// </summary>
    public static GameController Instance;

    /// <summary>
    /// Reference to the main camera in the scene
    /// </summary>
    public Camera primaryCamera;

    /// <summary>
    /// Sets the singleton
    /// </summary>
    private void Awake()
    {
        Instance = this;
    }
}
