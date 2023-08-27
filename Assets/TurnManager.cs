using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    // material references for changing colour of enemy during attack phases
    public Material BaseColour;
    public Material TimerColour;
    public Material AttackColour;
    public LayerMask mask;

    public GameObject Enemy; // enemy object reference

    // Start is called before the first frame update
    void Start()
    {
        Enemy.GetComponent<MeshRenderer>().material = BaseColour; // set colour of enemy
    }

    // Update is called once per frame
    void Update()
    {
        // player attack
        if(GameStateManager.gameState == GameState.PLAYERTURN && Input.GetKeyDown(KeyCode.Space))
        {
            GameStateManager.EnemyHealth--;
            Debug.Log(GameStateManager.EnemyHealth);
            GameStateManager.SetGameState(GameState.PLAYEREND); // end turn
        }

        if(GameStateManager.gameState == GameState.ENEMYTURN)
        {
            StartCoroutine(EnemyTurn());
            GameStateManager.SetGameState(GameState.ENEMYEND);
        }

        IEnumerator EnemyTurn() // enemy attack
        {
            Enemy.GetComponent<MeshRenderer>().material = TimerColour; // change colour for dodge window
            yield return new WaitForSeconds(1f);

            Enemy.GetComponent<MeshRenderer>().material = AttackColour; // change colour for attack

            if (Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity, mask))
            {
                var obj = hit.collider.gameObject;

                Debug.Log($"looking at {obj.name}", this);
            }

            yield return new WaitForSeconds(0.5f);

            Enemy.GetComponent<MeshRenderer>().material = BaseColour; // go back to normal colour
            yield break;
        }
    }
}
