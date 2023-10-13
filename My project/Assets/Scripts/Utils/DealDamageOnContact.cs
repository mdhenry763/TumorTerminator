using UnityEngine;

public class DealDamageOnContact : MonoBehaviour
{
    public int damage = 5;

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);

        //TryGet enemy health script


        //if(col.CompareTag("Enemy"))
        //{
        //    Debug.Log("Projectile has hit enemy");
        //}

    }
}
