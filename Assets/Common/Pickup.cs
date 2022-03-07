using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] Item.Type type;
    [SerializeField] GameObject pickupPrefab;

    [SerializeField] bool zeroY = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Inventory inventory))
        {
            if (inventory.AddItem(type))
            {
                if (pickupPrefab)
                {
                    Vector3 position = transform.position;
                    if (zeroY) position.y -= transform.position.y;

                    Instantiate(pickupPrefab, position, transform.rotation);
                }

                Destroy(gameObject);
            }
        }
    }
}
