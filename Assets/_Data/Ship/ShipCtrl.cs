using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : HaiMonoBehaviour
{
    [SerializeField] private Inventory inventory;
    public Inventory Inventory { get => inventory;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.GetComponentInChildren<Inventory>();
        Debug.Log(transform.name + ": LoadInventory", gameObject);
    }
}
