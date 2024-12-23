using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDrop : InventoryAbstract
{
    //[Header("Item Drop")]

    protected override void Start()
    {
        Invoke(nameof(this.Test), 5);
    }

    protected virtual void Test()
    {
        this.DropItemIndex(0);
    }
    protected virtual void DropItemIndex(int itemIndex) // ham roi item
    {
        //Debug.Log(itemIndex);
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        //Debug.Log(itemInventory.itemProfile.itemCode);
        //Debug.Log(itemInventory.upgradeLevel);

        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        ItemDropSpawner.Instance.DropFromInventory(itemInventory, dropPos, transform.rotation);
        this.inventory.Items.Remove(itemInventory);
    }
}
