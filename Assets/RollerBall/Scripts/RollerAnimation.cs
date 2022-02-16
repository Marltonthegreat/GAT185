using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RollerAnimation : MonoBehaviour
{
    [SerializeField] [Range(5f, 60)] float waitTime;
    [SerializeField] Animator animator;

    public float Timer { get; private set; } 

    public void Start()
    {
        Timer = waitTime;
    }

    public virtual void DecrementTimer(float amount = 1)
    {
        Timer -= amount;
        if (Timer <= 0) animator.SetTrigger("Toggle");
    }
    
    public virtual void ResetTimer()
    {
        Timer = waitTime;
    }
}
