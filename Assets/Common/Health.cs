using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject deathPrefab;
    [SerializeField] public AudioSource deathSound;
    [SerializeField] bool destroyOnDeath = true;
    [SerializeField] float maxHealth = 100;
    [SerializeField] bool destroyRoot = false;

    public float health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if(TryGetComponent(out IDestructable destructable))
            {
                destructable.Destroyed();
            }

            if (deathPrefab != null)
            {
                Instantiate(deathPrefab, transform.position, transform.rotation);
            }

            if (deathSound != null)
            {
                deathSound.Play();
            }

            if (destroyOnDeath)
            {
                if (destroyRoot) Destroy(gameObject.transform.root.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
