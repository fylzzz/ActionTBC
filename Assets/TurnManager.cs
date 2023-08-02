using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public Material BaseColour;
    public Material TimerColour;
    public Material AttackColour;

    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Enemy.GetComponent<MeshRenderer>().material = BaseColour;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameStateManager.gameState == GameState.PLAYERTURN && Input.GetKeyDown(KeyCode.Space))
        {
            GameStateManager.EnemyHealth--;
            Debug.Log(GameStateManager.EnemyHealth);
            GameStateManager.SetGameState(GameState.PLAYEREND);
        }

        if(GameStateManager.gameState == GameState.ENEMYTURN)
        {
            StartCoroutine(EnemyTurn());
            GameStateManager.SetGameState(GameState.ENEMYEND);
        }

        IEnumerator EnemyTurn()
        {
            Enemy.GetComponent<MeshRenderer>().material = TimerColour;
            yield return new WaitForSeconds(1f);

            Enemy.GetComponent<MeshRenderer>().material = AttackColour;
            yield return new WaitForSeconds(0.5f);

            Enemy.GetComponent<MeshRenderer>().material = BaseColour;
            yield break;
        }
    }
}
