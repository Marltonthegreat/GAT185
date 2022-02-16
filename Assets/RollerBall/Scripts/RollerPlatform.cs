using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerPlatform : MonoBehaviour
{
    [SerializeField] Animator animator;

    private float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Activate");
            timer = 5;
        }
    }

    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            animator.SetFloat("ResetTimer", timer);
        }
    }
}
