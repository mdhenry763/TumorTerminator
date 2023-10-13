using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int Health = 50;

    public static event Action OnEnemyDeath;

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0 )
        {
            OnEnemyDeath?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
