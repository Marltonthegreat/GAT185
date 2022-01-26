using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Health health))
        {
            health.Damage(damage);
        }
/*        if (gameObject.TryGetComponent(out health) && other.gameObject.TryGetComponent(out Damage otherDamage))
        {
            health.Damage(otherDamage.damage);
        }*/
    }
}
