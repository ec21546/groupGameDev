using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    public void TakeDamage(float damageAmount)
    {
        if (playerStats != null)
        {
            playerStats.health -= damageAmount;

            if (playerStats.health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        //playerStats.EndGame(); // Call the EndGame function from PlayerStats.
    }
}
