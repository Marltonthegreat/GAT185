using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Item[] items;

    List<Item> inventory = new List<Item>();
    public Item activeItem { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        inventory.AddRange(items);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ActivateItem(inventory[0]);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ActivateItem(inventory[1]);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ActivateItem(null);

        activeItem?.UpdateItem();
    }

    private void ActivateItem(Item item)
    {
        activeItem?.Deactivate();
        activeItem = item;
        activeItem?.Activate();
    }

    public void StartItem()
    {
        if (activeItem is Weapon weapon)
        {
            weapon.Fire();
        }
    }
}
