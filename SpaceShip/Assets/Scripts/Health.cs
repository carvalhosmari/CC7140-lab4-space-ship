using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public bool isPlayer;

    void Start()
    {
        currentHealth = maxHealth;
        GameManager.Instance.UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        GameManager.Instance.UpdateHealthUI();

        if (currentHealth <= 0)
        {
            if (isPlayer)
                GameManager.Instance.EndGame(false);
            else
                GameManager.Instance.EndGame(true);

            Destroy(gameObject);
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
