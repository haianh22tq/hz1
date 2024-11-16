using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : HaiMonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance { get => instance; }

    [SerializeField] private ShipCtrl currentShip;
    public ShipCtrl CurrentShip { get => currentShip;}

    [SerializeField] private PlayerPickUp playerPickUp;
    public PlayerPickUp PlayerPickUp { get => playerPickUp;}

    protected override void Awake()
    {
        base.Awake();
        PlayerCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickup();
    }

    protected virtual void LoadPlayerPickup()
    {
        if (this.playerPickUp != null) return;
        this.playerPickUp = transform.GetComponentInChildren<PlayerPickUp>();
        Debug.Log(transform.name + ": LoadPlayerPickup", gameObject);

    }

}
