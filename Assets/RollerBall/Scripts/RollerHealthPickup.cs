using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerHealthPickup : RollerPickup, IDestructable
{
    [SerializeField] int healAmount;

    public override void Destroyed()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        go.GetComponent<Health>().health += healAmount;
    }
}
