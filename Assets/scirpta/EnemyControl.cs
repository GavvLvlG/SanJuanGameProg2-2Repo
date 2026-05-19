using UnityEngine;

public class EnemyControl : MonoBehaviour, IDamageable
{
    public Animator animator;
    public float maxHealth = 100f;
    public float currentHealth;

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    void Update()
    {
       
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("IsHit");
        Debug.Log("Hit! Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetTrigger("IsDead");
        Debug.Log("Dead");
    }

    public float GetHealth()
    {
        return currentHealth;
    }
}