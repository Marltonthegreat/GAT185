using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCoin : MonoBehaviour
{
    public float amplitude = 1;
    public float rate = 1;
    public float spinRate = 1;

    Vector3 initialPosition;
    private float time;
    private float angle;

    private void Start()
    {
        time = Random.Range(0f, 5f);
        angle = Random.Range(0f, 360f);
        initialPosition = transform.position;
    }

    private void Update()
    {
        time += Time.deltaTime * rate;
        angle += Time.deltaTime * spinRate;

        Vector3 offset = Vector3.up * Mathf.Sin(time) * amplitude;
        transform.position = initialPosition + offset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
