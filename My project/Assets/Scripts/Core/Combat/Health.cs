using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;

    [field: SerializeField] public int MaxHealth { get; private set; } = 100;
    [field: SerializeField] public int CurrentHealth { get; private set; } = 100;

    private bool isDead;

    public Action<PlayerHealth> OnDie;
    public event Action<PlayerHealth> OnHealthChange;


    public void TakeDamage(int dmg)
    {
        Debug.Log("Take Damage");
        ModifyHealth(-dmg);
    }

    public void RestoreHealth(int health)
    {
        ModifyHealth(health);
    }

    private void ModifyHealth(int value)
    {
        if(isDead) return;

        CurrentHealth += value;
        OnHealthChange?.Invoke(this);

        Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        if(CurrentHealth <= 0 ) 
        {
            OnDie?.Invoke(this);
            if(deathScreen != null)
            {
                deathScreen.SetActive(true);
            }
            isDead = true;
        }
    }

}
