using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 [Serializable]
public class ItemInventory
{
    public ItemProfileSO itemProfile;//scriptableobject
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;

    public virtual ItemInventory ResetItem()
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemProfile = this.itemProfile,
            itemCount = this.itemCount,
            upgradeLevel = this.upgradeLevel
        };

        return itemInventory;
    }
}
