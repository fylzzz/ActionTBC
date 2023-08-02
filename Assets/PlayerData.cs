using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{

    public TMP_Text staminaData;
    public TMP_Text playerHealth;
    public TMP_Text enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        staminaData.SetText("Stamina: " + PlayerMovement.stamina);
        playerHealth.SetText("Player Health: " + GameStateManager.PlayerHealth);
        enemyHealth.SetText("Enemy Health: " + GameStateManager.EnemyHealth);
    }
}
