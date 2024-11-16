using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        Debug.Log("Item Pickup");
        ItemCode itemCode = itemPickupable.GetItemCode();
        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
        if (this.PlayerCtrl.CurrentShip.Inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
