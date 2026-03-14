using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Health playerHealth;
    public Health enemyHealth;

    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI enemyHealthText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;

    private bool gameEnded = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1f;
        UpdateHealthUI();
        gameOverPanel.SetActive(false);
    }

    public void UpdateHealthUI()
    {
        if (playerHealth != null)
            playerHealthText.text = "Player: " + playerHealth.GetCurrentHealth();

        if (enemyHealth != null)
            enemyHealthText.text = enemyHealth.GetCurrentHealth() + ":Enemy";
    }

    public void EndGame(bool playerWon)
    {
        if (gameEnded) return;

        gameEnded = true;
        gameOverPanel.SetActive(true);
        gameOverText.text = playerWon ? "VOCÊ VENCEU!" : "VOCÊ PERDEU!";

        Time.timeScale = 0f;
    }
}
