using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    int round;
    Text[] displayText;

    SpawnManager spawner;
    Player player;
    Core core;

    void Start() {
        spawner = FindObjectOfType<SpawnManager>();
        player = FindObjectOfType<Player>();
        core = FindObjectOfType<Core>();
        /*
        UpdateRound();
        UpdatePlayerHealth();
        UpdateCoreHealth();
        UpdateScore();
        */
        // subscriptions
        spawner.RoundChange += UpdateRound;
        player.TookDamage += UpdatePlayerHealth;
        core.TookDamage += UpdateCoreHealth;
        player.PointChange += UpdateScore;

        displayText = GetComponentsInChildren<Text>();
    }

    void UpdateRound() {
        round = spawner.GetRoundNum();
        displayText[0].text = "Round: " + round;
    }

    void UpdatePlayerHealth() {
        displayText[1].text = "Health: " + player.GetHealth();
    }

    public void UpdateCoreHealth() {
        displayText[2].text = "Core: " + core.GetHealth();
    }

    void UpdateScore() {
        displayText[3].text = "Score: " + player.GetPoints();
    }
}
