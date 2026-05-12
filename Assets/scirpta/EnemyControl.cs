using UnityEngine;

public class EnemyControl : MonoBehaviour, IDamageable
{
    public Animator animator;
    public float maxHealth;
    public float currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        animator.SetTrigger("IsHit");
        Debug.Log("Hit!");
        currentHealth = damage;
    }

    public void Die()
    {
        //animator.SetTrigger("Death");
        Debug.Log("Dead");
    }

    public float GetHealth()
    {
        return currentHealth;
    }

}
