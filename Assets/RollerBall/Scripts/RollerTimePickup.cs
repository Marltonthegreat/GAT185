using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerTimePickup : RollerPickup
{
    [SerializeField] [Range(-60, 60)] float timeMod = 0;

    public override void Destroyed()
    {
        RollerGameManager.Instance.GameTime += timeMod;
    }
}
