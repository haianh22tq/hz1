using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : JunkAbstract
{
    [SerializeField] protected SphereCollider _collider;

    public static ItemCode String2ItemCode(string itemName)
    {
        //ham chuyen kieu string cua String2ItemCode thanh kieu enum
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
    }
    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.2f;
        Debug.Log(transform.name + ": LoadTrigger", gameObject);
    }

    public virtual ItemCode GetItemCode()
    {
        return ItemPickupable.String2ItemCode(transform.parent.name);
    }
    public virtual void Picked()
    {
        this.junkCtrl.JunkDespawn.DespawnObject();
    }
}   
