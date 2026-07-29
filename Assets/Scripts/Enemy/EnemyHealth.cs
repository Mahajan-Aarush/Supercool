using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}