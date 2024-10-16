using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : HaiMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;//DANH  sach item

    protected override void Start()
    {
        base.Start();
        //this.AddItem(ItemCode.IronOre, 5);
    }
    //nhat do
    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);//lay item ra

        int newCount = itemInventory.itemCount + addCount;//tinh so lieu moi
        if (newCount > itemInventory.maxStack) return false;//neu khong vuot qua maxStack thi false

        itemInventory.itemCount = newCount;// neu vuot qua thi gan item vao
        return true;
    }

    public virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
        if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
        return itemInventory;

    }

    public virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("ItemProfile", typeof(ItemProfileSO));
        foreach(ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;

            ItemInventory itemInventory = new ItemInventory
            {
                itemProfile = profile,
                maxStack = profile.defaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }
        return null;
    }
}
