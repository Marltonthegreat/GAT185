using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    private float cooldown = 0;

    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && cooldown <= 0)
        {
            GameObject go = Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(go, 8);

            cooldown = .05f;
        }

        cooldown -= Time.deltaTime;
    }
}
