using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { PLAYERTURN, ENEMYTURN, PLAYEREND, ENEMYEND } // turn states
public class GameStateManager : MonoBehaviour
{
    public static GameState gameState { get; private set; }
    public static int EnemyHealth = 5; // self-explanatory
    public static int PlayerHealth = 10; // same again

    public void Start()
    {
        GameState gameState = GameState.PLAYERTURN;
        Debug.Log(gameState);
    }

    public void Update()
    {
        // change between states
        if(gameState == GameState.PLAYEREND)
        {
            SetGameState(GameState.ENEMYTURN);
        }
        if(gameState == GameState.ENEMYEND)
        {
            SetGameState(GameState.PLAYERTURN);
        }
    }

    public static void SetGameState(GameState state)
    {
        // ACTUALLy change the state
        gameState = state;
        Debug.Log("State Change:" + gameState);
    }
}
