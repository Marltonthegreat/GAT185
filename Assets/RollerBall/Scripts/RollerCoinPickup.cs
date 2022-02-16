using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCoinPickup : RollerPickup, IDestructable
{
    [SerializeField] int points;

    public override void Destroyed()
    {
        RollerGameManager.Instance.Score += points;

        if (GameObject.FindGameObjectsWithTag("Coin").Length <= 1)
        {
            RollerGameManager.Instance.state = RollerGameManager.State.GAME_ENDING;
        }
    }
}
