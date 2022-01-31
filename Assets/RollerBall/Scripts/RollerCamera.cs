using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distance = 5;
    [SerializeField] float pitch = 45;
    [SerializeField] float sensitivity = 5;

    private float yaw = 0;

    // Update is called once per frame
    void Update()
    {
        Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right);
        Vector3 offset = qpitch * Vector3.back * distance;

        transform.rotation = qpitch;
        transform.position = target.position + offset;
    }
}
