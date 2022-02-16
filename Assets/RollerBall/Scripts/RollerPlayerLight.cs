using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerPlayerLight : MonoBehaviour
{
    [SerializeField] Transform parentTransform;
    [SerializeField] Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = parentTransform.position + offset;
    }
}
