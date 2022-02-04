using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBackground : MonoBehaviour
{
    [SerializeField] GameObject background;

    // Update is called once per frame
    void Update()
    {
        if (background.transform.position.z <= -1450) background.transform.position = new Vector3(0, -100, 450);
    }
}
