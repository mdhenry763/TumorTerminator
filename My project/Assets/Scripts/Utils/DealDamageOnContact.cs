using UnityEngine;

public class DealDamageOnContact : MonoBehaviour
{
    public int damage = 5;

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);

        if(col.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
        {
            Debug.Log("Damage Dealt to enemies: " + damage);
            enemyHealth.TakeDamage(damage);
        }

    }
}
