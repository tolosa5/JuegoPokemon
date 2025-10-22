using UnityEngine;

public enum GameState
{
    MainMenu,
    Main,
    Battle,
    Inventory,
}

public class GameStatesManager : MonoBehaviour
{
    private GameState currentGameState = GameState.Main;
    public static GameStatesManager instance;
    
    public GameState CurrentGameState => currentGameState;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetGameState(GameState gameState)
    {
        currentGameState = gameState;
    }
}
