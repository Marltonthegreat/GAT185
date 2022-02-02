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
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        yaw %= 360;

        Quaternion qyaw = Quaternion.AngleAxis(yaw, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right);
        Quaternion rotation = qyaw * qpitch;


        Vector3 offset = rotation * Vector3.back * distance;

        transform.rotation = Quaternion.LookRotation(-offset);
        transform.position = target.position + offset;
    }
}
