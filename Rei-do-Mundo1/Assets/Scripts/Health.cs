using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private BossController RukasuController;
    [SerializeField] private Player_Controller playerController;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log(gameObject.name + " tomou " + damage + " de dano. Vida atual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " morreu!");
        if (CompareTag("Player"))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");

        }
        if (CompareTag("Rukasu"))
        {
            RukasuController.RukasuDeath();
        }
    }
}