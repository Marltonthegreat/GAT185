using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerHealthPickup : RollerPickup, IDesructable
{
    [SerializeField] int healAmount;

    public void Destroyed()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        go.GetComponent<Health>().health += healAmount;
    }
}
