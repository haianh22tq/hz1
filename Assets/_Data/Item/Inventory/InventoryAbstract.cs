using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAbstract : HaiMonoBehaviour
{
    [Header("Inventory Abstract")]
    [SerializeField] protected Inventory inventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.GetComponentInParent<Inventory>();
        Debug.LogWarning(transform.name + ":LoadInventory", gameObject);
    }
}
