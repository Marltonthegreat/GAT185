using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] bool oneTime = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!oneTime) return;

        if (other.gameObject.TryGetComponent(out Health health))
        {
            health.Damage(damage);
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (oneTime) return;

        if (other.gameObject.TryGetComponent(out Health health))
        {
            health.Damage(damage * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!oneTime) return;

        if (other.gameObject.TryGetComponent(out Health health))
        {
            health.Damage(damage);
        }
    }
}
