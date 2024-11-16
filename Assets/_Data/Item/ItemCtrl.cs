using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : HaiMonoBehaviour
{
    [SerializeField] private ItemPickupable itemPickupable;
    public ItemPickupable ItemPickupable { get => itemPickupable; }

    [SerializeField] private ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn { get => itemDespawn; }

    [SerializeField] private ItemInventory itemInventory;
    public ItemInventory ItemInventory { get => itemInventory; }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemPickupable();
        this.LoadItemDespawn();
        this.LoadItemInventory();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetItem();
    }

    protected virtual void LoadItemPickupable()
    {
        if (this.itemPickupable != null) return;
        this.itemPickupable = transform.GetComponentInChildren<ItemPickupable>();
    }
    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
    }

    protected virtual void LoadItemInventory()
    {
        if (this.itemInventory.itemProfile != null) return;
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfile = itemProfile;
        this.ResetItem();
    }

    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory.ResetItem();
        /*this.itemInventory = new ItemInventory();
        this.itemInventory.itemProfile = itemInventory.itemProfile;
        this.itemInventory.itemCount = itemInventory.itemCount;
        this.itemInventory.upgradeLevel = itemInventory.upgradeLevel;*/
    }

    protected virtual void ResetItem()
    {
        this.itemInventory.itemCount = 1;
        this.itemInventory.upgradeLevel = 0;
    }
}
