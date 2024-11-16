using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner.instance != null) Debug.Log("Eror Only 1 ItemDropSpawner allow to exits");
        ItemDropSpawner.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList, Vector3 pot, Quaternion rot)
    {
        if (dropList.Count < 1) return;
        ItemCode itemCode = dropList[0].itemSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pot, rot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }
    public virtual Transform Drop(ItemInventory itemInventory, Vector3 pot, Quaternion rot)
    {
        ItemCode itemCode = itemInventory.itemProfile.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pot, rot);
        if (itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);
        ItemCtrl itemCtrl = itemDrop.GetComponent<ItemCtrl>();
        itemCtrl.SetItemInventory(itemInventory);// sau khi roi thi set dung thong so item
        return itemDrop;
    }

}
