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
        ItemCode itemCode = dropList[0].itemSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pot, rot);
        itemDrop.gameObject.SetActive(true);
    } 
}
